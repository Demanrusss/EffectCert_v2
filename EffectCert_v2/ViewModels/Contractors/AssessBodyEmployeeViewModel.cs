using EffectCert.Helpers.Constants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EffectCert.ViewModels.Contractors
{
    public class AssessBodyEmployeeViewModel
    {
        public int Id { get; set; }
        [DisplayName("Сотрудник юридического лица")]
        public string ContractorLegalEmployeeFullName { get; set; } = null!;
        public int ContractorLegalEmployeeId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Позиция")]
        public string Position { get; set; } = null!;
        [DisplayName("Направление эксперта-аудитора")]
        public string? ExpertAuditorOrientation { get; set; }
    }
}
