namespace EffectCert.DAL.Entities.Contractors
{
    public class Laboratory
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public int ContractorLegalId { get; set; }
        public int? AttestateId { get; set; }
    }
}
