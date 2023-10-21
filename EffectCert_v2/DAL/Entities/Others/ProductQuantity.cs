﻿namespace EffectCert.DAL.Entities.Others
{
    public class ProductQuantity : IEntity
    {
        public int Id { get; set; }
        private int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public double Quantity { get; set; }
        private int MeasurementUnitId { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; } = null!;
    }
}
