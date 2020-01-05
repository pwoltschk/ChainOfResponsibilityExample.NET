using System;
using TransactionProcessing.BL.Model;

namespace TransactionProcessing.BL.Handlers.TransactionHandlers
{
    public abstract class TransactionHandler : IHandler<Order>
    {
        private IHandler<Order> Next { get; set; }

        public virtual void Handle(Order order)
        {
            throw new NotImplementedException();
        }

        public IHandler<Order> SetNext(IHandler<Order> next)
        {
            Next = next;

            return Next;
        }
    }
}
