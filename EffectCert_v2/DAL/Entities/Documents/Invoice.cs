namespace EffectCert.DAL.Entities.Documents
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public string Number { get; set; } = null!;
        public DateTime? Date { get; set; }
    }
}
