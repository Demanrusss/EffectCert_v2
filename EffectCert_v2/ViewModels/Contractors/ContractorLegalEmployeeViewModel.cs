namespace EffectCert.ViewModels.Contractors
{
    public class ContractorLegalEmployeeViewModel
    {
        public int Id { get; set; }
        public ContractorIndividualViewModel ContractorIndividual { get; set; } = null!;
        public ContractorLegalViewModel ContractorLegal { get; set; } = null!;
        public string Position { get; set; } = null!;
        public bool IsManager { get; set; } = false;
    }
}
