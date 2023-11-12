using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;

namespace EffectCert.DAL.Entities.Main
{
    public class ExpertDecision : IEntity, IDocument
    {
        public int Id { get; set; }
        public string Number { get; set; } = String.Empty;
        public DateTime Date { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; } = null!;
        public string? ConformityMarkInfo { get; set; }
        public int ExpertId { get; set; }
        public AssessBodyEmployee Expert { get; set; } = null!;
        public DateTime? ValidDate { get; set; }
        public int? DocsAnalizeExpertId { get; set; }
        public AssessBodyEmployee? DocsAnalizeExpert { get; set; }
        public DateTime? DocsAnalizeExpertSignDate { get; set; }
        public ICollection<TestProtocol> TestProtocols { get; set; } = new HashSet<TestProtocol>();
    }
}
