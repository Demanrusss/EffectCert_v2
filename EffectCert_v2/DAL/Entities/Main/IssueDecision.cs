using EffectCert.DAL.Entities.Documents;

namespace EffectCert.DAL.Entities.Main
{
    public class IssueDecision : IEntity, IDocument
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; } = null!;
        public int CertificateId { get; set; }
        public Certificate Certificate { get; set; } = null!;
        public int ExpertDecisionId { get; set; }
        public ExpertDecision ExpertDecision { get; set; } = null!;
        public int RecommendationId { get; set; }
        public Recommendation Recommendation { get; set; } = null!;
    }
}
