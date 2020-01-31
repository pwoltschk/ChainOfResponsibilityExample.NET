namespace TransactionProcessor.BL.Handler
{
    public interface IReceiver<T> where T : class
    {
        void Handle(T request);
    }
}
