namespace EffectCert.DAL.Entities.Contractors
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public string Country { get; set; } = null!;
        public string? Index { get; set; }
        public string? AddressLine { get; set; }
    }
}
