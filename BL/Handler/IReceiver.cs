namespace TransactionProcessing.BL.Handlers
{
    public interface IReceiver<T> where T : class
    {
        void Handle(T request);
    }
}
