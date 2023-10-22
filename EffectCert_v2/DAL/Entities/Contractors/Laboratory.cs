using EffectCert.DAL.Entities.Documents;

namespace EffectCert.DAL.Entities.Contractors
{
    public class Laboratory : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        private int ContractorLegalId { get; set; }
        public ContractorLegal ContractorLegal { get; set; } = null!;
        private int? AttestateId { get; set; }
        public Attestate? Attestate { get; set; }
        public ICollection<LaboratoryEmployee> Employees { get; set; } = new List<LaboratoryEmployee>();
    }
}
