namespace EffectCert.DAL.Entities.Others
{
    public class SelectedSampleQuantity : IEntity
    {
        public int Id { get; set; }
        public int ProductQuantityId { get; set; }
        public ProductQuantity ProductQuantity { get; set; } = null!;
        public double Quantity { get; set; }
        public int MeasurementUnitId { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; } = null!;
    }
}
