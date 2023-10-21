namespace EffectCert.DAL.Entities.Others
{
    public class MeasurementUnit : IEntity
    {
        public int Id { get; set; }
        public string ShortName { get; set; } = null!;
        public string FullName { get; set; } = null!;
    }
}
