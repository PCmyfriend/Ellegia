using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ellegia.Application.Dtos
{
    public class OrderDto
    {
        public CustomerDto Customer { get; set; }
        //public WarehouseDto Warehouse { get; set; }
        public ProductTypeDto ProductType { get; set; }
        public ICollection<PermittedOrderRouteDto> PermittedRoutes { get; set; }
        
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int WarehouseId { get; set; }
        public int QuantityInKg { get; set; }
        public decimal PricePerKg { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductTypeId { get; set; }
        public bool IsMine { get; set; }
        public bool IsDeletionPermitted { get; set; }
        public bool IsCompletionPermitted { get; set; }
        public string Name { get; set; }

        public OrderDto()
        {
            PermittedRoutes = new Collection<PermittedOrderRouteDto>();
        }

    }
}
