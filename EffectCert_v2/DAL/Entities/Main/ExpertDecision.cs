namespace EffectCert.DAL.Entities.Main
{
    public class ExpertDecision
    {
        public int Id { get; set; }
        public string Number { get; set; } = String.Empty;
        public DateTime Date { get; set; }
        public int ApplicationId { get; set; }
        public string? ConformityMarkInfo { get; set; }
        public int ExpertId { get; set; }
        public DateTime? ValidDate { get; set; }
        public int? DocsAnalizeExpertId { get; set; }
        public DateTime? DocsAnalizeExpertSignDate { get; set; }
    }
}
