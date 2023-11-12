using EffectCert.DAL.Entities.Documents;

namespace EffectCert.DAL.Entities.Contractors
{
    public class Laboratory : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public int ContractorLegalId { get; set; }
        public ContractorLegal ContractorLegal { get; set; } = null!;
        public int? AttestateId { get; set; }
        public Attestate? Attestate { get; set; }
        public ICollection<LaboratoryEmployee> LaboratoryEmployees { get; set; } = new HashSet<LaboratoryEmployee>();
    }
}
