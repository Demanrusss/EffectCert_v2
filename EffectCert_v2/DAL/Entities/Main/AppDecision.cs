using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Others;

namespace EffectCert.DAL.Entities.Main
{
    public class AppDecision : IEntity, IDocument
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        private int ApplicationId { get; set; }
        public Application Application { get; set; } = null!;
        private int ActionPlanId { get; set; }
        public ActionPlan ActionPlan { get; set; } = null!;
        private int? ProductionAnalyzeAssessBodyId { get; set; }
        public AssessBody? ProductionAnalyzeAssessBody { get; set; }
        private int? ProductionAnalyzeLaboratoryId { get; set; }
        public Laboratory? ProductionAnalyzeLaboratory { get; set; }
        private int? InspectionAssessBodyId { get; set; }
        public AssessBody? InspectionAssessBody { get; set; }
        private int? InspectionLaboratoryId { get; set; }
        public Laboratory? InspectionLaboratory { get; set; }
        public string? InspectionPeriod { get; set; }
        private int? SchemaAnotherId { get; set; }
        public Schema? SchemaAnother { get; set; }
        public string? DeclarationNumber { get; set; }
        public DateTime? DeclarationDate { get; set; }
        public string? AssessContractNumber { get; set; }
        public DateTime? AssessContractDate { get; set; }
    }
}
