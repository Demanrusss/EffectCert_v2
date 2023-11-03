using System.ComponentModel;

namespace EffectCert.ViewModels.Contractors
{
    public class ContractorLegalEmployeeViewModel
    {
        public int Id { get; set; }
        [DisplayName("Физическое лицо")]
        public ContractorIndividualViewModel ContractorIndividual { get; set; } = null!;
        [DisplayName("Юридическое лицо")]
        public ContractorLegalViewModel ContractorLegal { get; set; } = null!;
        [DisplayName("Позиция")]
        public string Position { get; set; } = null!;
        [DisplayName("Является руководителем")]
        public bool IsManager { get; set; } = false;
    }
}
