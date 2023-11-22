namespace EffectCert.DAL.Entities.Contractors
{
    public class ContractorLegal : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public string? BIN { get; set; }
        public int RegAddressId { get; set; }
        public Address RegAddress { get; set; } = null!;
        public int FactAddressId { get; set; }
        public Address FactAddress { get; set; } = null!;
        public int? BankAccountId { get; set; }
        public BankAccount? BankAccount { get; set; }
        public ICollection<ContractorLegalEmployee> Employees { get; set; } = new HashSet<ContractorLegalEmployee>();
    }
}
