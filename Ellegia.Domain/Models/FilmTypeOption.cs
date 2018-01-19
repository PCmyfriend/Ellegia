using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class FilmTypeOption : Entity, ICommonHandbook
    {
        public string Name { get; private set; }

        protected FilmTypeOption()
        {
            // required by EF
        }

        public FilmTypeOption(int id, string name)
        {
            Id = id;
            Name = name;
        }       
    } 
}
