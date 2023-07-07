namespace EffectCert.DAL.Entities.Documents
{
    public class ManufacturerStandard
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public string Name { get; set; } = null!;
        public DateTime? Date { get; set; }
    }
}
