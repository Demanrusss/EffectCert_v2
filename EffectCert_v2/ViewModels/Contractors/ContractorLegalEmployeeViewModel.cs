using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EffectCert.ViewModels.Contractors
{
    public class ContractorLegalEmployeeViewModel
    {
        public int? Id { get; set; }
        [DisplayName("Физическое лицо")]
        public ContractorIndividualViewModel? ContractorIndividual { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int ContractorIndividualId { get; set; }
        [DisplayName("Позиция")]
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public string Position { get; set; } = null!;
        [DisplayName("Является руководителем")]
        public bool IsManager { get; set; } = false;
    }
}
