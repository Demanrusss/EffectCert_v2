using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EffectCert.ViewModels.Contractors
{
    public class LaboratoryEmployeeViewModel
    {
        public int Id { get; set; }
        [DisplayName("Сотрудник юридического лица")]
        public ContractorLegalEmployeeViewModel? ContractorLegalEmployee { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int ContractorLegalEmployeeId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Позиция")]
        public string Position { get; set; } = null!;
    }
}
