using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;

namespace EffectCert.ViewModels.Contractors
{
    public class ContractorLegalEmployeeViewModel
    {
        public int Id { get; set; }
        [DisplayName("Физическое лицо")]
        public ContractorIndividualViewModel ContractorIndividual { get; set; } = null!;
        public int ContractorIndividualId { get; set; }
        [DisplayName("Позиция")]
        public string Position { get; set; } = null!;
        [DisplayName("Является руководителем")]
        public bool IsManager { get; set; } = false;
    }
}
