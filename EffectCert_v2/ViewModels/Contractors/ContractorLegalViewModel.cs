using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EffectCert.ViewModels.Contractors
{
    public class ContractorLegalViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Полное наименование")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Сокращенное наименование")]
        public string ShortName { get; set; } = null!;
        [DisplayName("БИН")]
        public string? BIN { get; set; }
        [DisplayName("Адрес регистрации")]
        public AddressViewModel? RegAddress { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int RegAddressId { get; set; }
        [DisplayName("Адрес фактический")]
        public AddressViewModel? FactAddress { get; set; }
        public int FactAddressId { get; set; }
        [DisplayName("Адреса совпадают")]
        public bool IsAddressSame { get; set; }
        [DisplayName("Банковский счет")]
        public BankAccountViewModel? BankAccount { get; set; }
        public int? BankAccountId { get; set; }
        [DisplayName("Сотрудники")]
        public ICollection<ContractorLegalEmployeeViewModel> Employees { get; set; } = new HashSet<ContractorLegalEmployeeViewModel>();
        public int[]? EmployeesIds { get; set; }
    }
}
