using EffectCert.DAL.Entities.Main;

namespace EffectCert.DAL.Entities.Documents
{
    public class TechReg : IEntity
    {
        public int Id { get; set; }
        public string? Number { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public string ApprovedByInfo { get; set; } = null!;
        public string? Paragraphs { get; set; }

        public ICollection<Application> Applications { get; set; } = new HashSet<Application>();
    }
}
