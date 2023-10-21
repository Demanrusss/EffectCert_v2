using EffectCert.DAL.Entities.Documents;

namespace EffectCert.DAL.Entities.Main
{
    public class IssueDecision : IEntity, IDocument
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        private int ApplicationId { get; set; }
        public Application Application { get; set; } = null!;
        private int CertificateId { get; set; }
        public Certificate Certificate { get; set; } = null!;
        private int ExpertDecisionId { get; set; }
        public ExpertDecision ExpertDecision { get; set; } = null!;
        private int RecommendationId { get; set; }
        public Recommendation Recommendation { get; set; } = null!;
    }
}
