using TransactionProcessing.BL.Handlers.TransactionHandlers;
using TransactionProcessing.BL.Model;
using System;

namespace TransactionProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order();

            order.LineItems.Add(new Item("B0023", "Philips Hue TV 42 Zoll", 1299), 2);
            order.LineItems.Add(new Item("S0174", "iPhone X", 700), 1);

            order.SelectedTransactions.Add(new Transaction
            {
                TransactionProvider = TransactionProvider.Paypal,
                Amount = 1000
            });

            order.SelectedTransactions.Add(new Transaction
            {
                TransactionProvider = TransactionProvider.Invoice,
                Amount = 1797
            });

            Console.WriteLine(order.AmountDue);
            Console.WriteLine(order.ShippingStatus);


            var handler = new TransactionHandler(
                new PaypalHandler(),
                new InvoiceHandler(), 
                new CardHandler()
            );

            handler.Handle(order);

            Console.WriteLine(order.AmountDue);
            Console.WriteLine(order.ShippingStatus);
        }
    }
}
