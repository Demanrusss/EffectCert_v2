namespace EffectCert.ViewModels.Contractors
{
    public class AssessBodyEmployeeViewModel
    {
        public int Id { get; set; }
        private int ContractorLegalEmployeeId { get; set; }
        public ContractorLegalEmployeeViewModel ContractorLegalEmployee { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string? ExpertAuditorOrientation { get; set; }
    }
}
