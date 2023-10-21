using EffectCert.DAL.Entities.Contractors;

namespace EffectCert.DAL.Entities.Documents
{
    public class TestProtocol : IEntity, IDocument
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        private int LaboratoryId { get; set; }
        public Laboratory Laboratory { get; set; } = null!;
    }
}
