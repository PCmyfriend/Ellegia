using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        public int HolderId { get; private set; }

        protected Order()
        {
            OrderRoutes = new Collection<OrderRoute>();
            OrderStatus = OrderStatus.OnEditing;
        }
        
        public decimal TotalPrice => PricePerKg * QuantityInKg;

        public void Send(OrderRoute orderRoute)
        {   
            OrderRoutes.Add(orderRoute);    
            HolderId = orderRoute.RecipientId; 
        }

        public void ChangeStatus(OrderStatus orderStatus)
        {
            OrderStatus = orderStatus;
        }

        public bool IsUserCreator(int userId)
        {
            var orderRoute = OrderRoutes.FirstOrDefault();

            if (orderRoute == null)
                return false;

            return orderRoute.SenderId == userId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ellegiaUsers">
        /// Набор пользователей при котором разрешенно удаление заказа.
        /// В таблице OrderRoutes должны быть пользователи только из этой 
        /// коллеции для того чтобы заказ было доступен для удаления.
        /// </param>
        /// <returns></returns>
        public bool IsDeletionPermitted(IEnumerable<EllegiaUser> ellegiaUsers)
        {
            var recepientIds = OrderRoutes.GroupBy(orderRoutes => orderRoutes.RecipientId).Select(b => b.Key);
            var diff = recepientIds.Except(ellegiaUsers.Select(u => u.Id));
                    
            if(diff.Any()) 
                return false;

            return true;
        }

        public bool IsAviableForUser(int userId)
        {
            return OrderRoutes.Any(orderRoutes => orderRoutes.RecipientId == userId);
        }
    }
}