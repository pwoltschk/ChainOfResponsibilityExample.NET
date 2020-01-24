using System.Linq;
using TransactionProcessing.BL.Model;
using TransactionProcessing.BL.TransactionProcessors;

namespace TransactionProcessing.BL.Handlers.TransactionHandlers
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
