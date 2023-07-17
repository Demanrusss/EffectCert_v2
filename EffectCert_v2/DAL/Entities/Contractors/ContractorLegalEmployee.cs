namespace EffectCert.DAL.Entities.Contractors
{
    public class ContractorLegalEmployee
    {
        public int Id { get; set; }
        public int ContractorIndividualId { get; set; }
        public int ContractorLegalId { get; set; }
        public string Position { get; set; } = null!;
        public bool IsManager { get; set; } = false;
    }
}
