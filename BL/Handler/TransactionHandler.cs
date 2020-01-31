using System;
using System.Collections.Generic;
using TransactionProcessor.BL.Exception;
using TransactionProcessor.BL.Model;

namespace TransactionProcessor.BL.Handler.TransactionHandler
{
    public class TransactionHandler
    {
        private readonly IList<IReceiver<Order>> receivers;

        public TransactionHandler(params IReceiver<Order>[] receivers)
        {
            this.receivers = receivers;
        }

        public void Handle(Order order)
        {
            foreach (var receiver in receivers)
            {
                Console.WriteLine($"Execution of: {receiver.GetType().Name}");

                if (order.AmountDue > 0)
                {
                    receiver.Handle(order);
                }
                else
                {
                    break;
                }
            }

            if (order.AmountDue > 0)
            {
                throw new InsufficientBalanceException();
            }
            else
            {
                order.ShippingStatus = ShippingStatus.ReadyForShippment;
            }
        }

        public void SetNext(IReceiver<Order> next)
        {
            receivers.Add(next);
        }
    }
}
