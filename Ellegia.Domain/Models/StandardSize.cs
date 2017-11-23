using System.Diagnostics.Contracts;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class StandardSize : Entity
    {
        public int PlasticBagTypeId { get; private set; }
        
        public float WidthInCm { get; private set; }
        public float LengthInCm { get; private set; }
        public int QuantityInBag { get; private set; }
        public float? HeightInCm { get; private set; }

        protected StandardSize()
        {
            // required EF constructor
        }

        public StandardSize(float widthInCm, float lengthInCm, int quantityInBag)
        {
            Contract.Requires(widthInCm > 0, "Width in cm should be greater than zero.");
            Contract.Requires(lengthInCm > 0, "Length in cm shoud be greater than zero.");
            Contract.Requires(quantityInBag > 0, "Quantity in a bag should be greater than zero.");

            WidthInCm = widthInCm;
            LengthInCm = lengthInCm;
            QuantityInBag = quantityInBag;
        }

        public StandardSize(float widthInCm, float lengthInCm, int quantityInBag, float heightInCm)
            : this(widthInCm, lengthInCm, quantityInBag)
        {
            Contract.Requires(heightInCm > 0);

            HeightInCm = heightInCm;
        }
    }
}