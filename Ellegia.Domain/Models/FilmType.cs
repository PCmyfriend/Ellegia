using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class FilmType : Entity, ICommonHandbook
    {
        public ICollection<FilmType> Childs { get; private set; }
        public FilmType Parent { get; private set; }

        public string Name { get; private set; }

        public int? ParentId { get; private set; }

        protected FilmType()
        {
            Childs = new Collection<FilmType>();
        }

        public FilmType(int id, string name)
            : this()
        {   
            Id = id;
            Name = name;
        }     
    }
}
 