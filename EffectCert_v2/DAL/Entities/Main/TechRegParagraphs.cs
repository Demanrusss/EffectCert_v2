using EffectCert.DAL.Entities.Documents;

namespace EffectCert.DAL.Entities.Main
{
    public class TechRegParagraphs
    {
        public int Id { get; set; }
        public TechReg? TechReg { get; set; }
        public int TechRegId { get; set; }
        public string? Paragraphs { get; set; }

        public ICollection<Application> Applications { get; set; } = new HashSet<Application>(); 
    }
}
