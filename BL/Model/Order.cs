using System.Collections.Generic;
using System.Linq;

namespace TransactionProcessing.BL.Model
{
    public class Order
    {
        public Dictionary<Item, int> LineItems { get; } = new Dictionary<Item, int>();

        public IList<Transaction> SelectedTransactions { get; } = new List<Transaction>();

        public IList<Transaction> CompletedTransactions { get; } = new List<Transaction>();

        public decimal AmountDue => LineItems.Sum(item => item.Key.Price * item.Value) - CompletedTransactions.Sum(payment => payment.Amount);

    }

    public enum TransactionProvider
    {
        Paypal,
        Card,
        Invoice
    }

    public class Transaction
    {
        public decimal Amount { get; set; }
        public TransactionProvider TransactionProvider { get; set; }
    }

    public class Item
    {
        public string Id { get; }
        public string Name { get; }
        public decimal Price { get; }

        public Item(string id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}