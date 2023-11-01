namespace EffectCert.DAL.Entities.Others
{
    public class SelectedSampleQuantity : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public double Quantity { get; set; }
        public int MeasurementUnitId { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; } = null!;
    }
}
