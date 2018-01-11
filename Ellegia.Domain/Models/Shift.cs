using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class Shift: Entity, ICommonHandbook
    {
        public string Name { get; private set; }    
            
        public int SupervisorId { get; private set; } 

        protected Shift()
        {
            // required by EF
        }

        public Shift(int id, string name)
        {
            Id = id;
            Name = name;    
        }   
    }
}
