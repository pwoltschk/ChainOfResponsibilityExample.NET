using System.Linq;
using TransactionProcessor.BL.Model;
using TransactionProcessor.BL.TransactionProcessors;

namespace TransactionProcessor.BL.Handler.TransactionHandler
{
    internal class CreditBalanceReceiver : IReceiver<Order>
    {
        public readonly CreditBalanceTransactionProcessor _balanceTransactionProcessor;

        public CreditBalanceReceiver(CreditBalanceTransactionProcessor balanceTransactionProcessor)
        {
            _balanceTransactionProcessor = balanceTransactionProcessor;
        }

        public void Handle(Order order)
        {
            if (order.SelectedTransactions.Any(x => x.TransactionProvider == TransactionProvider.Card))
            {
                _balanceTransactionProcessor.Complete(order);
            }
        }
    }
}
