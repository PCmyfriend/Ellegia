using System.Diagnostics.Contracts;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class OrderPaymentInfo : Entity
    {
        public OrderPaymentStatus Status { get; private set; }
        
        protected OrderPaymentInfo()
        {
            Status = OrderPaymentStatus.NotPaid;
        }
        
        public OrderPaymentInfo(Order order)
            : this()
        {
            Contract.Requires(order != null);

            Id = order.Id;
        }

        public bool IsPaid => Status == OrderPaymentStatus.Paid;
    }
}