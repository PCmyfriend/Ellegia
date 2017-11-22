using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class OrderStatus : Entity, ICommonHandbook
    {
        public string Name { get; private set; }

        public OrderStatus(int id, string name)
        {
            Id = id;
            Name = name;
        }

        protected OrderStatus()
        {
            // empty constructor for EF
        }
    }
}
