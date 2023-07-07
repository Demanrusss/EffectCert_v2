namespace EffectCert.DAL.Entities.Main
{
    public class Recommendation
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        public int ApplicationId { get; set; }
        public int DecisionId { get; set; }
        public int SelectProductsActId { get; set; }
        public int ExpertDecisionId { get; set; }
    }
}
