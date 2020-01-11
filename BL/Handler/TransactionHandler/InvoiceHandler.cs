using TransactionProcessing.BL.Model;
using TransactionProcessing.BL.TransactionProcessors;
using System.Linq;

namespace TransactionProcessing.BL.Handlers.TransactionHandlers
{
    public class InvoiceHandler : TransactionHandler
    {
        public InvoiceTransactionProcessor InvoiceTransactionProcessor { get; }
            = new InvoiceTransactionProcessor();

        public override void Handle(Order order)
        {
            if (order.SelectedTransactions.Any(x => x.TransactionProvider == TransactionProvider.Invoice))
            {
                InvoiceTransactionProcessor.Complete(order);
            }
            base.Handle(order);
        }
    }
}
