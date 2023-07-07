namespace EffectCert.DAL.Entities.Main
{
    public class IssueDecision
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        public int ApplicationId { get; set; }
        public int CertificateId { get; set; }
        public int ExpertDecisionId { get; set; }
        public int RecommendationId { get; set; }
    }
}
