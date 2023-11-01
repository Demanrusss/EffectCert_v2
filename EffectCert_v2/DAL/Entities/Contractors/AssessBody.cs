using EffectCert.DAL.Entities.Documents;

namespace EffectCert.DAL.Entities.Contractors
{
    public class AssessBody : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;
        public int ContractorLegalId { get; set; }
        public ContractorLegal ContractorLegal { get; set; } = null!;
        public int AttestateId { get; set; }
        public Attestate Attestate { get; set; } = null!;
        public ICollection<AssessBodyEmployee> AssessBodyEmployees { get; set;} = new List<AssessBodyEmployee>();
    }
}
