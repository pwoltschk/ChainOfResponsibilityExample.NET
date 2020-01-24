using System.Linq;
using TransactionProcessing.BL.Model;
using TransactionProcessing.BL.TransactionProcessors;

namespace TransactionProcessing.BL.Handlers.TransactionHandlers
{
    public class PaypalReceiver : IReceiver<Order>
    {
        private PaypalTransactionProcessor PaypalTransactionProcessor { get; }
            = new PaypalTransactionProcessor();

        public void Handle(Order order)
        {
            if (order.SelectedTransactions.Any(x => x.TransactionProvider == TransactionProvider.Paypal))
            {
                PaypalTransactionProcessor.Complete(order);
            }
        }
    }
}
