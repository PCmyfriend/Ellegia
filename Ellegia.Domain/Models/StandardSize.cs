using System.Diagnostics.Contracts;
using Ellegia.Domain.Contracts.Common;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class StandardSize : Entity, ICommonHandbook
    {
        public PlasticBagType PlasticBagType { get; private set; }

        public int PlasticBagTypeId { get; private set; }
        public int WidthInMm { get; private set; }
        public int LengthInMm { get; private set; }
        public int? HeightInMm { get; private set; }
        public int QuantityInBag { get; private set; }

        public string Name {
            get {
                var widthInCm = ToCmString(WidthInMm);
                var lengthInCm = ToCmString(LengthInMm);
                var heightInCm = HeightInMm.HasValue ? ToCmString(HeightInMm.Value) : string.Empty;
                return $"{widthInCm}x{lengthInCm}x{heightInCm} cm";
            }
        }

        protected StandardSize()
        {
            // required by EF
        }

        public StandardSize(int widthInMm, int lengthInMm, int? heightInMm, int quantityInBag)
        {
            Contract.Requires(widthInMm > 0, "Width should be greater than zero.");
            Contract.Requires(lengthInMm > 0, "Length shoud be greater than zero.");
            Contract.Requires(quantityInBag > 0, "Quantity in a bag should be greater than zero.");

            WidthInMm = widthInMm;
            LengthInMm = lengthInMm;
            HeightInMm = heightInMm;
            QuantityInBag = quantityInBag;
        }

        public StandardSize(int plasticBagTypeId, int widthInMm, int lengthInMm, int? heightInMm, int quantityInBag)
            : this(widthInMm, lengthInMm, heightInMm, quantityInBag)
        {
            PlasticBagTypeId = plasticBagTypeId;
        }

        private static string ToCmString(int value)
        {
            var valueInMm = value / 10.0;
            return $"{valueInMm:F1}";
        }
    }
}