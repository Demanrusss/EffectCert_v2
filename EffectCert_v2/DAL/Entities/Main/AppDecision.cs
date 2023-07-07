namespace EffectCert.DAL.Entities.Main
{
    public class AppDecision
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        public int ApplicationId { get; set; }
        public int ActionPlanId { get; set; }
        public int? ProductionAnalyzeAssessBodyId { get; set; }
        public int? ProductionAnalyzeLaboratoryId { get; set; }
        public int? InspectionAssessBodyId { get; set; }
        public int? InspectionLaboratoryId { get; set; }
        public string? InspectionPeriod { get; set; }
        public int? SchemaAnotherId { get; set; }
        public string? DeclarationNumber { get; set; }
        public DateTime? DeclarationDate { get; set; }
        public string? AssessContractNumber { get; set; }
        public DateTime? AssessContractDate { get; set; }
    }
}
