using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class Order : Entity
    {
        public ICollection<OrderRoute> OrderRoutes { get; private set; }
        public Customer Customer { get; private set; }
        public Warehouse Warehouse { get; private set; }
        public ProductType ProductType { get; private set; }

        public int CustomerId { get; private set; }
        public int WarehouseId { get; private set; }
        public int ProductTypeId { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public int QuantityInKg { get; private set; }
        public decimal PricePerKg { get; private set; }
        public decimal TotalSum { get; private set; }

        protected Order()
        {
            OrderRoutes = new Collection<OrderRoute>();
            OrderStatus = OrderStatus.Active;
        }

        public Order(int customerId, int warehouseId, OrderStatus orderStatus, int quantityInKg, 
            decimal pricePerKg, decimal totalSum, int productTypeId) : this()
        {
            CustomerId = customerId;
            WarehouseId = warehouseId;
            OrderStatus = orderStatus;  
            QuantityInKg = quantityInKg;
            PricePerKg = pricePerKg;
            TotalSum = totalSum;
            ProductTypeId = productTypeId;
        }

        public void TransferOrder(OrderRoute orderRoute)
        {
            OrderRoutes.Add(orderRoute);
        }
    }
}
