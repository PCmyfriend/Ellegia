using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class FilmType : Entity, ICommonHandbook
    {
        public string Name { get; private set; }

        protected FilmType()
        {
            // empty constructor for EF
        }

        public FilmType(int id, string name)
        {   
            Id = id;
            Name = name;
        }     
    }
}
 