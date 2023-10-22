namespace EffectCert.DAL.Entities.Contractors
{
    public class ContractorLegal : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public string? BIN { get; set; }
        private int RegAddressId { get; set; }
        public Address RegAddress { get; set; } = null!;
        private int FactAddressId { get; set; }
        public Address FactAddress { get; set; } = null!;
        private int? BankAccountId { get; set; }
        public BankAccount? BankAccount { get; set; }
        public ICollection<ContractorLegalEmployee> Employees { get; set; } = new List<ContractorLegalEmployee>();
    }
}
