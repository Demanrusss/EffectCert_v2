using EffectCert.DAL.Entities.Contractors;

namespace EffectCert.ViewModels.Contractors
{
    public class ContractorLegalViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public string? BIN { get; set; }
        public AddressViewModel RegAddress { get; set; } = null!;
        public AddressViewModel? FactAddress { get; set; }
        public bool IsAddressSame { get; set; }
        public BankAccountViewModel? BankAccount { get; set; }
        public ICollection<ContractorLegalEmployeeViewModel> Employees { get; set; } = new List<ContractorLegalEmployeeViewModel>();
    }
}
