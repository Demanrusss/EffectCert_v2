using EffectCert.DAL.Entities.Contractors;

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
        private int ManufacturerId { get; set; }
        public ContractorLegal Manufacturer { get; set; } = null!;
        public string TNVED { get; set; } = null!;
        public DateTime? MadeDate { get; set; }
    }
}
