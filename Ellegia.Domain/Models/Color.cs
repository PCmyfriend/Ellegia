using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class Color : Entity, ICommonHandbook
    {
        public string Name { get; private set; }

        protected Color()
        {
            // empty constructor for EF
        }

        public Color(int id, string name)
        {
            Id = id;
            Name = name;
        }               
    }
}