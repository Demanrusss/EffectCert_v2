using EffectCert.Helpers.Constants;
using System.ComponentModel.DataAnnotations;

namespace EffectCert.ViewModels.Contractors
{
    public class AssessBodyEmployeeViewModel
    {
        public int Id { get; set; }
        public ContractorLegalEmployeeViewModel ContractorLegalEmployee { get; set; } = null!;
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public string Position { get; set; } = null!;
        public string? ExpertAuditorOrientation { get; set; }
    }
}
