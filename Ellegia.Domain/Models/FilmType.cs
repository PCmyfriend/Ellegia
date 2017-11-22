﻿using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class FilmType : Entity, ICommonHandbook
    {
        public string Name { get; set; }

        public FilmType(int id, string name)
        {   
            Id = id;
            Name = name;
        }

        protected FilmType()
        {
            // empty constructor for EF
        }
    }
}
 