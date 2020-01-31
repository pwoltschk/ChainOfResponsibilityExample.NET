using TransactionProcessor.BL.Model;

namespace TransactionProcessor.BL.TransactionProcessors
{
    public interface ITransactionProcessor
    {
        void Complete(Order order);
    }
}
