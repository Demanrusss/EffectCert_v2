namespace EffectCert.DAL.Entities.Main
{
    public class Recommendation : IEntity, IDocument
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; } = null!;
        public int AppDecisionId { get; set; }
        public AppDecision AppDecision { get; set; } = null!;
        public int SelectProductsActId { get; set; }
        public SelectProductsAct SelectProductsAct { get; set; } = null!;
        public int ExpertDecisionId { get; set; }
        public ExpertDecision ExpertDecision { get; set; } = null!;
    }
}
