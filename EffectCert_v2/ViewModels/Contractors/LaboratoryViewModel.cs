using EffectCert.ViewModels.Documents;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EffectCert.ViewModels.Contractors
{
    public class LaboratoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Полное наименование")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Сокращенное наименование")]
        public string ShortName { get; set; } = null!;
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Юридическое лицо")]
        public ContractorLegalViewModel ContractorLegal { get; set; } = null!;
        public int ContractorLegalId { get; set; }
        [DisplayName("Аттестат")]
        public AttestateViewModel? Attestate { get; set; } = null!;
        public int? AttestateId { get; set; }
        [DisplayName("Сотрудники органа")]
        public ICollection<LaboratoryEmployeeViewModel> LaboratoryEmployees { get; set; } = new HashSet<LaboratoryEmployeeViewModel>();
    }
}
