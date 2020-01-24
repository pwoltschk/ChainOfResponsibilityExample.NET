using System.Linq;
using TransactionProcessing.BL.Model;
using TransactionProcessing.BL.TransactionProcessors;

namespace TransactionProcessing.BL.Handlers.TransactionHandlers
{
    public class InvoiceReceiver : IReceiver<Order>
    {
        public InvoiceTransactionProcessor InvoiceTransactionProcessor { get; }
            = new InvoiceTransactionProcessor();

        public void Handle(Order order)
        {
            if (order.SelectedTransactions.Any(x => x.TransactionProvider == TransactionProvider.Invoice))
            {
                InvoiceTransactionProcessor.Complete(order);
            }
        }
    }
}
