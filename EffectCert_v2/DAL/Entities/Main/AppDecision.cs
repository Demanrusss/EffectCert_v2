using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Others;

namespace EffectCert.DAL.Entities.Main
{
    public class AppDecision : IEntity, IDocument
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; } = null!;
        public int ActionPlanId { get; set; }
        public ActionPlan ActionPlan { get; set; } = null!;
        public int? ProductionAnalyzeAssessBodyId { get; set; }
        public AssessBody? ProductionAnalyzeAssessBody { get; set; }
        public int? ProductionAnalyzeLaboratoryId { get; set; }
        public Laboratory? ProductionAnalyzeLaboratory { get; set; }
        public int? InspectionAssessBodyId { get; set; }
        public AssessBody? InspectionAssessBody { get; set; }
        public int? InspectionLaboratoryId { get; set; }
        public Laboratory? InspectionLaboratory { get; set; }
        public string? InspectionPeriod { get; set; }
        public int? SchemaAnotherId { get; set; }
        public Schema? SchemaAnother { get; set; }
        public string? DeclarationNumber { get; set; }
        public DateTime? DeclarationDate { get; set; }
        public string? AssessContractNumber { get; set; }
        public DateTime? AssessContractDate { get; set; }
    }
}
