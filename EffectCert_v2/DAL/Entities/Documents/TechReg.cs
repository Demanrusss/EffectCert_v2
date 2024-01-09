using EffectCert.DAL.Entities.Main;
using System.ComponentModel.DataAnnotations.Schema;

namespace EffectCert.DAL.Entities.Documents
{
    public class TechReg : IEntity
    {
        public int Id { get; set; }
        public string? Number { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public string ApprovedByInfo { get; set; } = null!;
    }
}
