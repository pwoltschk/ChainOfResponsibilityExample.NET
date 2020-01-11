using TransactionProcessing.BL.Exception;
using TransactionProcessing.BL.Model;

namespace TransactionProcessing.BL.Handlers.TransactionHandlers
{
    public abstract class TransactionHandler : IHandler<Order>
    {
        private IHandler<Order> Next { get; set; }

        public virtual void Handle(Order order)
        {
            if (Next == null && order.AmountDue > 0)
            {
                throw new InsufficientBalanceException();
            }

            if (order.AmountDue > 0)
            {
                Next.Handle(order);
            }
            else
            {
                order.ShippingStatus = ShippingStatus.ReadyForShippment;
            }
        }

        public IHandler<Order> SetNext(IHandler<Order> next)
        {
            Next = next;

            return Next;
        }
    }
}
