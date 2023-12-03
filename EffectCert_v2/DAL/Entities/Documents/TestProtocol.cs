using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Main;

namespace EffectCert.DAL.Entities.Documents
{
    public class TestProtocol : IEntity, IDocument
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        public int LaboratoryId { get; set; }
        public Laboratory Laboratory { get; set; } = null!;

        public virtual ICollection<ExpertDecision> ExpertDecisions { get; set; }
    }
}
