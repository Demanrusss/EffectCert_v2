using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Entities.Others;

namespace EffectCert.DAL.Entities.Main
{
    public class Application : IEntity, IDocument
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        public int AssessBodyId { get; set; }
        public AssessBody AssessBody { get; set; } = null!;
        public int ContractorLegalId { get; set; }
        public ContractorLegal ContractorLegal { get; set; } = null!;
        public string? ElectronicNumber { get; set; }
        public DateTime? ElectronicDate { get; set; }
        public int SchemaId { get; set; }
        public Schema Schema { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public ICollection<ProductQuantity> ProductQuantities { get; set; } = new HashSet<ProductQuantity>();
        public ICollection<TechRegParagraphs> TechRegsParagraphs { get; set; } = new HashSet<TechRegParagraphs>();
        public ICollection<GovStandardParagraphs> GovStandardsParagraphs { get; set; } = new HashSet<GovStandardParagraphs>();
    }
}
