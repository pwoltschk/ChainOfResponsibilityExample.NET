using TransactionProcessing.BL.Model;
using TransactionProcessing.BL.TransactionProcessors;
using System.Linq;

namespace TransactionProcessing.BL.Handlers.TransactionHandlers
{
    public class CardReceiver : IReceiver<Order>
    {
        public CardTransactionProcessor CardTransactionProcessor { get; }
            = new CardTransactionProcessor();

        public void Handle(Order order)
        {
            if (order.SelectedTransactions.Any(x => x.TransactionProvider == TransactionProvider.Card))
            {
                CardTransactionProcessor.Complete(order);
            }
        }
    }
}
