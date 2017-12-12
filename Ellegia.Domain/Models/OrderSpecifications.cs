using System.Diagnostics.Contracts;
using Ellegia.Domain.Core.Models;

namespace Ellegia.Domain.Models
{
    public class OrderSpecifications : Entity
    {
        // EF includes
        public StandardSize StandardSize { get; private set; }
        public FilmTypeOption FilmTypeOption { get; private set; }
        public FilmType FilmType { get; private set; }
        public Color Color { get; private set; }
        
        public int QuantityInKg { get; private set; }
        public bool HasCorona { get; private set;  }
        public float ThicknessInMicron { get; private set;  }
        public int StandardSizeId { get; private set; }
        public int FilmTypeOptionId { get; private set; }
        public int FilmTypeId { get; private set; }
        public int ColorId { get; private set; }

        protected OrderSpecifications()
        {
            // required constructor for EF
        }
        
        public OrderSpecifications(
            Order order,
            int quantityInKg, 
            bool hasCorona, 
            float thicknessInMicron, 
            StandardSize standardSize,
            FilmTypeOption filmTypeOption,
            FilmType filmType,
            Color color)
        {
            Contract.Requires(quantityInKg > 0);
            Contract.Requires(thicknessInMicron > 0);
            Contract.Requires(standardSize != null);
            Contract.Requires(filmTypeOption != null);
            Contract.Requires(filmType != null);
            Contract.Requires(color != null);

            Id = order.Id;
            QuantityInKg = quantityInKg;
            HasCorona = hasCorona;
            ThicknessInMicron = thicknessInMicron;
            StandardSizeId = standardSize.Id;
            FilmTypeOptionId = filmTypeOption.Id;
            FilmTypeId = filmType.Id;
            ColorId = color.Id;
        }
    }
}