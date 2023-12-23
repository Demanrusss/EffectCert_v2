namespace EffectCert.DAL.Entities.Others
{
    public class Schema : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<CertObject> CertObjects { get; set; } = new HashSet<CertObject>();
    }
}
