namespace EffectCert.DAL.Entities.Contractors
{
    public class ContractorLegal : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public string? BIN { get; set; }
        public int RegAddressId { get; set; }
        public int? FactAddressId { get; set; }
        public int? BankAccountId { get; set; }
        public ICollection<ContractorLegalEmployee> Employees { get; set; } = new List<ContractorLegalEmployee>();
    }
}
