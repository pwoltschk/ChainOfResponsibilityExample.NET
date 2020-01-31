using System.Linq;
using TransactionProcessor.BL.Model;
using TransactionProcessor.BL.TransactionProcessors;

namespace TransactionProcessor.BL.Handler.TransactionHandler
{
    public class CardReceiver : IReceiver<Order>
    {
        public readonly CardTransactionProcessor _cardTransactionProcessor;

        public CardReceiver(CardTransactionProcessor cardTransactionProcessor)
        {
            _cardTransactionProcessor = cardTransactionProcessor;
        }

        public void Handle(Order order)
        {
            if (order.SelectedTransactions.Any(x => x.TransactionProvider == TransactionProvider.Card))
            {
                _cardTransactionProcessor.Complete(order);
            }
        }
    }
}
