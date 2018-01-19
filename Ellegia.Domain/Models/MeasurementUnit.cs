using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class MeasurementUnit : Entity, ICommonHandbook
    {
        public string Name { get; private set; }
        public bool IsInteger { get; private set; }

        protected MeasurementUnit()
        {
            // required by EF
        }

        public MeasurementUnit(int id, string name, bool isInteger)
        {
            Id = id;
            Name = name;
            IsInteger = isInteger;
        }
    }
}