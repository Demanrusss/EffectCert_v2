namespace EffectCert.DAL.Entities.Others
{
    public class ProductQuantity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public int MeasurementUnitId { get; set; }
    }
}
