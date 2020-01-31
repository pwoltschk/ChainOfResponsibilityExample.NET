namespace TransactionProcessor.BL.Model
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public TransactionProvider TransactionProvider { get; set; }
    }
}