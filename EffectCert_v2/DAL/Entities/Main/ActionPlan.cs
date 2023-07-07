namespace EffectCert.DAL.Entities.Main
{
    public class ActionPlan
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        public int ApplicationId { get; set; }
        public int AppAnalizeExpertId { get; set; }
        public int ConformityAssessBodyHeadId { get; set; }
        public int? SelectProductEmployeeId { get; set; }
        public int? ResultsAnalizeExpertId { get; set; }
        public int? RegDocumentEmployeeId { get; set; }
    }
}
