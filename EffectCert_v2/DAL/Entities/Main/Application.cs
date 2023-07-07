namespace EffectCert.DAL.Entities.Main
{
    public class Application
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        public int AssessBodyId { get; set; }
        public int ContractorLegalId { get; set; }
        public string? ElectronicNumber { get; set; }
        public DateTime? ElectronicDate { get; set; }
        public int SchemaId { get; set; }
    }
}
