namespace EffectCert.DAL.Entities.Contractors
{
    public class AssessBodyEmployee : IEntity
    {
        public int Id { get; set; }
        private int ContractorLegalEmployeeId { get; set; }
        public ContractorLegalEmployee ContractorLegalEmployee { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string? ExpertAuditorOrientation { get; set; }
    }
}
