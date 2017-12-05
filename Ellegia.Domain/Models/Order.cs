using System.Diagnostics.Contracts;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class Order : Entity
    {
        // Possible EF includes
        public OrderSpecifications Specifications { get; private set; }
        public OrderPaymentInfo PaymentInfo { get; private set; }
        
        public OrderStatus Status { get; private set; }

        protected Order()
        {
            Status = OrderStatus.Active;
            PaymentInfo = new OrderPaymentInfo(this);
        }

        public Order(OrderSpecifications specifications, OrderPaymentInfo paymentInfo)
            : this()
        {
            Contract.Requires(specifications != null);
            Contract.Requires(paymentInfo != null);

            Specifications = specifications;
            PaymentInfo = paymentInfo;
        }

        public bool IsActive => Status == OrderStatus.Active;
        
        public bool Release()
        {
            if (!PaymentInfo.IsPaid) 
                return false;
            
            Status = OrderStatus.Released;
            return true;
        }
    }
}