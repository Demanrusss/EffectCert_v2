using EffectCert.DAL.Entities.Contractors;

namespace EffectCert.DAL.Entities.Main
{
    public class ActionPlan : IEntity, IDocument
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        private int ApplicationId { get; set; }
        public Application Application { get; set; } = null!;
        private int AppAnalizeExpertId { get; set; }
        public AssessBodyEmployee AppAnalizeExpert { get; set; } = null!;
        private int ConformityAssessBodyHeadId { get; set; }
        public AssessBodyEmployee ConformityAssessBodyHead { get; set; } = null!;
        private int? SelectProductEmployeeId { get; set; }
        public ContractorLegalEmployee? SelectProductEmployee { get; set; }
        private int? ResultsAnalizeExpertId { get; set; }
        public AssessBodyEmployee? ResultsAnalizeExpert { get; set; }
        private int? RegDocumentEmployeeId { get; set; }
        public AssessBodyEmployee? RegDocumentEmployee { get; set; }
    }
}
