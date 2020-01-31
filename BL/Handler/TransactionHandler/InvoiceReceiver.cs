using System.Linq;
using TransactionProcessor.BL.Model;
using TransactionProcessor.BL.TransactionProcessors;

namespace TransactionProcessor.BL.Handler.TransactionHandler
{
    public class InvoiceReceiver : IReceiver<Order>
    {
        public readonly InvoiceTransactionProcessor _invoiceTransactionProcessor;

        public InvoiceReceiver(InvoiceTransactionProcessor invoiceTransactionProcessor)
        {
            _invoiceTransactionProcessor = invoiceTransactionProcessor;
        }

        public void Handle(Order order)
        {
            if (order.SelectedTransactions.Any(x => x.TransactionProvider == TransactionProvider.Invoice))
            {
                _invoiceTransactionProcessor.Complete(order);
            }
        }
    }
}
