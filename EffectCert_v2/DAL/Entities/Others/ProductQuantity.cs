using EffectCert.DAL.Entities.Main;

namespace EffectCert.DAL.Entities.Others
{
    public class ProductQuantity : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public double Quantity { get; set; }
        public int MeasurementUnitId { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; } = null!;
        public DateTime MadeDate { get; set; }

        public virtual ICollection<Application> Applications { get; set; } = new HashSet<Application>();
    }
}
