using System.Linq;
using TransactionProcessor.BL.Model;

namespace TransactionProcessor.BL.TransactionProcessors
{
    public class CreditBalanceTransactionProcessor : ITransactionProcessor
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
