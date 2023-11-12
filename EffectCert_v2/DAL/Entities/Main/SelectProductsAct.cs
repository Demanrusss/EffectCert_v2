using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Others;

namespace EffectCert.DAL.Entities.Main
{
    public class SelectProductsAct : IEntity, IDocument
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; } = null!;
        public int ActionPlanId { get; set; }
        public ActionPlan ActionPlan { get; set; } = null!;
        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;
        public int SupplierId { get; set; }
        public ContractorLegal Supplier { get; set; } = null!;
        public string StorageCondition { get; set; } = null!;
        public string PackageType { get; set; } = null!;
        public int ControlSamplesStorageTime { get; set; }
        public string ControlSamplesQuantity { get; set; } = null!;
        public ICollection<SelectedSampleQuantity> Products { get; set; } = new HashSet<SelectedSampleQuantity>();
    }
}
