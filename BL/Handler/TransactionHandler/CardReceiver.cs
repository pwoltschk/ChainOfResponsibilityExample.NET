using System.Linq;
using TransactionProcessing.BL.Model;
using TransactionProcessing.BL.TransactionProcessors;

namespace TransactionProcessing.BL.Handlers.TransactionHandlers
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
