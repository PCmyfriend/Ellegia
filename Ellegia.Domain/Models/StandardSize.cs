using System.Diagnostics.Contracts;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class StandardSize : Entity
    {
        
        public PlasticBagType PlasticBagType { get; private set; }
        
        public int PlasticBagTypeId { get; private set; }
        
        public float WidthInCm { get; private set; }
        public float HeightInCm { get; private set; }
        public int QuantityInBag { get; private set; }

        protected StandardSize()
        {
            // empty constructor for EF
        }

        public StandardSize(float widthInCm, float heightInCm, int quantityInBag)
        {
            Contract.Requires(widthInCm > 0, "Width in cm should be greater than zero.");
            Contract.Requires(heightInCm > 0, "Length in cm shoud be greater than zero.");
            Contract.Requires(quantityInBag > 0, "Quantity in a bag should be greater than zero.");

            WidthInCm = widthInCm;
            HeightInCm = heightInCm;
            QuantityInBag = quantityInBag;
        }
    }
}