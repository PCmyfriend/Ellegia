using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class FilmType : Entity, ICommonHandbook
    {
        public ICollection<FilmType> Children { get; private set; }
        public FilmType Parent { get; private set; }

        public string Name { get; private set; }

        public int? ParentId { get; private set; }

        protected FilmType()
        {
            Children = new Collection<FilmType>();
        }

        public FilmType(int id, string name)
            : this()
        {   
            Id = id;
            Name = name;
        }

        public FilmType(int id, string name, int parentId)
            : this(id, name)
        {
            ParentId = parentId;
        }
    }
}
 