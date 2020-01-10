using System.Linq;
using TransactionProcessing.BL.Model;

namespace TransactionProcessing.BL.TransactionProcessors
{
    public class InvoiceTransactionProcessor : ITransactionProcessor
    {
        public void Complete(Order order)
        {
            var payment = order.SelectedTransactions
                .FirstOrDefault(x => x.TransactionProvider == TransactionProvider.Invoice);

            if (payment == null) return;

            order.CompletedTransactions.Add(payment);
        }
    }
}
