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
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Адрес")]
        public AddressViewModel Address { get; set; } = null!;
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Юридическое лицо")]
        public ContractorLegalViewModel ContractorLegal { get; set; } = null!;
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Аттестат")]
        public AttestateViewModel Attestate { get; set; } = null!;
        [DisplayName("Сотрудники органа")]
        public ICollection<AssessBodyEmployeeViewModel> AssessBodyEmployees { get; set; } = new List<AssessBodyEmployeeViewModel>();
    }
}
