namespace EffectCert.DAL.Entities.Others
{
    public class MeasurementUnit : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
    }
}
