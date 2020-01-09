using System.Linq;
using TransactionProcessing.BL.Model;

namespace TransactionProcessing.BL.TransactionProcessors
{
    public class PaypalTransactionProcessor : ITransactionProcessor
    {
        public void Complete(Order order)
        {
            var payment = order.SelectedTransactions
                .FirstOrDefault(x => x.TransactionProvider == TransactionProvider.Paypal);

            if (payment == null) return;

            order.CompletedTransactions.Add(payment);
        }
    }
}
