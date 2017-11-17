using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class PlasticBagType : Entity, ICommonHandbook
    {
        public string Name { get; private set; }

        public PlasticBagType(int id, string name)
        {
            Id = id;
            Name = name;
        }
        
        protected PlasticBagType()
        {
            // empty constructor for EF
        }
    }
}