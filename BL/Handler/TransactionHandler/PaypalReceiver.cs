using System.Linq;
using TransactionProcessor.BL.Model;
using TransactionProcessor.BL.TransactionProcessors;

namespace TransactionProcessor.BL.Handler.TransactionHandler
{
    public class PaypalReceiver : IReceiver<Order>
    {
        private readonly PaypalTransactionProcessor _paypalTransactionProcessor;

        public PaypalReceiver(PaypalTransactionProcessor paypalTransactionProcessor)
        {
            _paypalTransactionProcessor = paypalTransactionProcessor;
        }

        public void Handle(Order order)
        {
            if (order.SelectedTransactions.Any(x => x.TransactionProvider == TransactionProvider.Paypal))
            {
                _paypalTransactionProcessor.Complete(order);
            }
        }
    }
}
