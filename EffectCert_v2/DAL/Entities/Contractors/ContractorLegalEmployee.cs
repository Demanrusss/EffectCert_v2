namespace EffectCert.DAL.Entities.Contractors
{
    public class ContractorLegalEmployee : IEntity
    {
        public int Id { get; set; }
        public int ContractorIndividualId { get; set; }
        public ContractorIndividual ContractorIndividual { get; set; } = null!;
        public string Position { get; set; } = null!;
        public bool IsManager { get; set; } = false;
        public int? ContractorLegalId { get; set; }
    }
}
