using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Main;

namespace EffectCert.DAL.Entities.Others
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? GroupName { get; set; }
        public string? Type { get; set; }
        public string? TradeMark { get; set; }
        public string? Model { get; set; }
        public string? Article { get; set; }
        public int ManufacturerId { get; set; }
        public ContractorLegal Manufacturer { get; set; } = null!;
        public string TNVED { get; set; } = null!;

        public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}
