using System.Linq;
using TransactionProcessing.BL.Model;

namespace TransactionProcessing.BL.TransactionProcessors
{
    public class CardTransactionProcessor : ITransactionProcessor
    {
        public void Complete(Order order)
        {
            // Invoke the Stripe API
            var payment = order.SelectedTransactions
                .FirstOrDefault(x => x.TransactionProvider == TransactionProvider.Card);

            if (payment == null) return;

            order.CompletedTransactions.Add(payment);
        }
    }
}
