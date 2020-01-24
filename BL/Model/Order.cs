using System.Collections.Generic;
using System.Linq;

namespace TransactionProcessing.BL.Model
{
    public class Order
    {
        public Dictionary<Item, int> LineItems { get; } = new Dictionary<Item, int>();

        public IList<Transaction> SelectedTransactions { get; } = new List<Transaction>();

        public IList<Transaction> CompletedTransactions { get; } = new List<Transaction>();

        public decimal AmountDue => LineItems.Sum(item => item.Key.Price * item.Value) - CompletedTransactions.Sum(transaction => transaction.Amount);

        public ShippingStatus ShippingStatus { get; set; } = ShippingStatus.WaitingForSettlement;
    }
}