using TransactionProcessing.BL.Model;

namespace TransactionProcessing.BL.TransactionProcessors
{
    public interface ITransactionProcessor
    {
        void Complete(Order order);
    }
}
