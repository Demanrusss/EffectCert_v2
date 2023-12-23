namespace EffectCert.DAL.Entities.Others
{
    public class CertObject : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Schema> Schemas { get; set; } = new HashSet<Schema>();
    }
}
