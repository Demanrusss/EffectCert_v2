namespace EffectCert.DAL.Entities.Contractors
{
    public class AssessBodyEmployee
    {
        public int Id { get; set; }
        public int ContractorLegalEmployeeId { get; set; }
        public string Position { get; set; } = null!;
        public string? ExpertAuditorOrientation { get; set; }
    }
}
