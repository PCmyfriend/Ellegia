using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class Color : Entity, ICommonHandbook
    {
        public string Name { get; private set; }

        protected Color()
        {
            // required by EF
        }

        public Color(string name)
        {
            Name = name;
        }               
    }
}