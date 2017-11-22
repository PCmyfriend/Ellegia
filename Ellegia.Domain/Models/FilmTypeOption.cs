using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class FilmTypeOption : Entity, ICommonHandbook
    {
        public string Name { get; private set; }    

        public FilmTypeOption(int id, string name)
        {
            Id = id;
            Name = name;
        }

        protected FilmTypeOption()
        {
            // empty constructor for EF
        }
    } 
}
