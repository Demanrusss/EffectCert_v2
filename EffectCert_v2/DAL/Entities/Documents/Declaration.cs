namespace EffectCert.DAL.Entities.Documents
{
    public class Declaration : IEntity, IDocument
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        public DateTime? ValidDate { get; set; }
    }
}
