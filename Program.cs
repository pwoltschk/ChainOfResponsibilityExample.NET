using System;
using TransactionProcessor.BL.Handler.TransactionHandler;
using TransactionProcessor.BL.Model;
using TransactionProcessor.BL.TransactionProcessors;

namespace TransactionProcessor
{
    class Program
    {
        static void Main(string[] args)
        {

            var handler = BootstrapCoR();
            Order order = CreateOrder();

            PrintOrderState(order);

            handler.Handle(order);

            PrintOrderState(order);
        }

        private static Order CreateOrder()
        {
            var order = new Order();

            order.LineItems.Add(new Item("B0023", "Philips Hue TV 42 Zoll", 1299), 2);
            order.LineItems.Add(new Item("S0174", "iPhone X", 700), 1);

            order.SelectedTransactions.Add(new Transaction
            {
                TransactionProvider = TransactionProvider.Paypal,
                Amount = 500
            });

            order.SelectedTransactions.Add(new Transaction
            {
                TransactionProvider = TransactionProvider.Invoice,
                Amount = 400
            });
            return order;
        }

        private static TransactionHandler BootstrapCoR()
        {
            return new TransactionHandler(
                new CreditBalanceReceiver(new CreditBalanceTransactionProcessor()),
                new PaypalReceiver(new PaypalTransactionProcessor()),
                new InvoiceReceiver(new InvoiceTransactionProcessor()),
                new CardReceiver(new CardTransactionProcessor())
            );
        }

        private static void PrintOrderState(Order order)
        {
            Console.WriteLine(order.AmountDue);
            Console.WriteLine(order.ShippingStatus);
        }
    }
}
