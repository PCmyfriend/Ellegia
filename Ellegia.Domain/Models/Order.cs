using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class Order : Entity
    {
        public Order(int customerId, int warehouseId, OrderStatus orderStatus, int quantityInKg, 
            decimal pricePerKg, decimal totalSum, int productTypeId)
        {
            CustomerId = customerId;
            WarehouseId = warehouseId;
            OrderStatus = orderStatus;
            QuantityInKg = quantityInKg;
            PricePerKg = pricePerKg;
            TotalSum = totalSum;
            ProductTypeId = productTypeId;
        }

        public int CustomerId { get; set; }
        public int WarehouseId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int QuantityInKg { get; set; }
        public decimal PricePerKg { get; set; }
        public decimal TotalSum { get; set; }
        public int ProductTypeId { get; set; }

        public Customer Customer { get; set; }
        public Warehouse Warehouse { get; set; }
        public ProductType ProductType { get; set; }
    }
}
