﻿using System.Collections.Generic;
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

        public int? ParentId
        {
            get => _parentId;
            private set => _parentId = value == 0 ? null : value;
        }

        private int? _parentId;

        protected FilmType()
        {
            Children = new Collection<FilmType>();
        }

        public FilmType(string name)
            : this()
        {   
            Name = name;
        }

        public FilmType(string name, int parentId)
            : this(name)
        {
            ParentId = parentId;
        }
    }
}
 