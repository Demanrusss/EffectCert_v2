using EffectCert.DAL.Entities.Main;

namespace EffectCert.DAL.Entities.Documents
{
    public class GovStandardParagraphs : IEntity
    {
        public int Id { get; set; }
        public GovStandard? GovStandard { get; set; }
        public int GovStandardId { get; set; }
        public string Paragraphs { get; set; } = null!;

        public ICollection<Application> Applications { get; set; } = new HashSet<Application>();
    }
}
