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
        public decimal TotalPrice { get; private set; } 
        public int HolderId { get; private set; } 

        protected Order()
        {
            OrderRoutes = new Collection<OrderRoute>();
            OrderStatus = OrderStatus.Active;
        }

        public Order(
            int customerId, 
            int warehouseId,
            int quantityInKg, 
            decimal pricePerKg,
            int productTypeId) 
            : this()
        {
            CustomerId = customerId;
            WarehouseId = warehouseId;  
            QuantityInKg = quantityInKg;
            PricePerKg = pricePerKg;
            TotalPrice = pricePerKg * quantityInKg;
            ProductTypeId = productTypeId;
        }   

        public void Send(OrderRoute orderRoute)
        {   
            OrderRoutes.Add(orderRoute);
            HolderId = orderRoute.RecipientId;
        }
    }
}
