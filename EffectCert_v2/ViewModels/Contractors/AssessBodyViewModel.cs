using EffectCert.ViewModels.Documents;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EffectCert.ViewModels.Contractors
{
    public class AssessBodyViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Полное наименование")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Сокращенное наименование")]
        public string ShortName { get; set; } = null!;
        [DisplayName("Адрес")]
        public AddressViewModel? Address { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int AddressId { get; set; }
        [DisplayName("Юридическое лицо")]
        public ContractorLegalViewModel? ContractorLegal { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int ContractorLegalId { get; set; }
        [DisplayName("Аттестат")]
        public AttestateViewModel? Attestate { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int AttestateId { get; set; }
        [DisplayName("Сотрудники органа")]
        public ICollection<AssessBodyEmployeeViewModel> Employees { get; set; } = new HashSet<AssessBodyEmployeeViewModel>();
        public int[]? EmployeesIds { get; set; }
    }
}
