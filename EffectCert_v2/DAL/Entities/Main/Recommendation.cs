namespace EffectCert.DAL.Entities.Main
{
    public class Recommendation : IEntity, IDocument
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        private int ApplicationId { get; set; }
        public Application Application { get; set; } = null!;
        private int DecisionId { get; set; }
        public AppDecision Decision { get; set; } = null!;
        private int SelectProductsActId { get; set; }
        public SelectProductsAct SelectProductsAct { get; set; } = null!;
        private int ExpertDecisionId { get; set; }
        public ExpertDecision ExpertDecision { get; set; } = null!;
    }
}
