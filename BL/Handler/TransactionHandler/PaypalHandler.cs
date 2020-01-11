using TransactionProcessing.BL.Model;
using TransactionProcessing.BL.TransactionProcessors;
using System.Linq;

namespace TransactionProcessing.BL.Handlers.TransactionHandlers
{
    public class PaypalHandler : TransactionHandler
    {
        private PaypalTransactionProcessor PaypalTransactionProcessor { get; }
            = new PaypalTransactionProcessor();

        public override void Handle(Order order)
        {
            if (order.SelectedTransactions.Any(x => x.TransactionProvider == TransactionProvider.Paypal))
            {
                PaypalTransactionProcessor.Complete(order);
            }

            base.Handle(order);
        }
    }
}
