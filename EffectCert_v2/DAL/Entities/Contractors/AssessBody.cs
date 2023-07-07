namespace EffectCert.DAL.Entities.Contractors
{
    public class AssessBody
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public int AddressId { get; set; }
        public int ContractorLegalId { get; set; }
        public int AttestateId { get; set; }
    }
}
