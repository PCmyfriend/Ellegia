using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class Shift: Entity, ICommonHandbook
    {
        public string Name { get; private set; }

        public Shift(int id, string name)
        {
            Id = id;
            Name = name;    
        }

        protected Shift()
        {
            // empty constructor for EF
        }
    }
}
