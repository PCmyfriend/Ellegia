using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class FilmTypeOptions : Entity, ICommonHandbook
    {
        public string Name { get; set; }

        public FilmTypeOptions(int id, string name)
        {
            Id = id;
            Name = name;
        }

        protected FilmTypeOptions()
        {
            // empty constructor for EF
        }
    } 
}
