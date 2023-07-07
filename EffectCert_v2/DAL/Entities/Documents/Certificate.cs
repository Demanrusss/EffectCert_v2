namespace EffectCert.DAL.Entities.Documents
{
    public class Certificate
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        public DateTime? ValidDate { get; set; }
    }
}
