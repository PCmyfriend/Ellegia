﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class PlasticBagType : Entity, ICommonHandbook
    {
        public ICollection<StandardSize> StandardSizes { get; private set; }
        
        public string Name { get; private set; }  
   
        protected PlasticBagType()
        {
            StandardSizes = new Collection<StandardSize>();
        }

        public PlasticBagType(string name) : this()
        {
            Name = name;
        }

        public void AddStandardSize(StandardSize standardSize)
        {
            StandardSizes.Add(standardSize);
        }

        public StandardSize FindStandardSize(int id)
        {
            return StandardSizes.SingleOrDefault(ss => ss.Id == id);
        }

        public bool RemoveStandardSize(int id)
        {
            var standardSize = FindStandardSize(id);

            return standardSize != null && StandardSizes.Remove(standardSize);
        }
    }
}