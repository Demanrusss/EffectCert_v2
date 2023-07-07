namespace EffectCert.DAL.Entities.Main
{
    public class SelectProductsAct
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        public int ApplicationId { get; set; }
        public int ActionPlanId { get; set; }
        public int AddressId { get; set; }
        public int SupplierId { get; set; }
        public string StorageCondition { get; set; } = null!;
        public string PackageType { get; set; } = null!;
        public int ControlSamplesStorageTime { get; set; }
        public string ControlSamplesQuantity { get; set; } = null!;
    }
}
