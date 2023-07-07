namespace EffectCert.DAL.Entities.Others
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? GroupName { get; set; }
        public string? Type { get; set; }
        public string? TradeMark { get; set; }
        public string? Model { get; set; }
        public string? Article { get; set; }
        public int ManufacturerId { get; set; }
        public string TNVED { get; set; } = null!;
        public DateTime? MadeDate { get; set; }
    }
}
