using System.Linq;
using TransactionProcessing.BL.Model;
using TransactionProcessing.BL.TransactionProcessors;

namespace TransactionProcessing.BL.Handlers.TransactionHandlers
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
