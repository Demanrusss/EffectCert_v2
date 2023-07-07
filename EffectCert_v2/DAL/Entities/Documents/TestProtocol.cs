namespace EffectCert.DAL.Entities.Documents
{
    public class TestProtocol
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        public int LaboratoryId { get; set; }
    }
}
