using EffectCert.DAL.Entities.Main;

namespace EffectCert.DAL.Entities.Documents
{
    public class TechRegParagraphs : IEntity
    {
        public int Id { get; set; }
        public TechReg? TechReg { get; set; }
        public int TechRegId { get; set; }
        public string? Paragraphs { get; set; }

        public ICollection<Application> Applications { get; set; } = new HashSet<Application>();
    }
}
