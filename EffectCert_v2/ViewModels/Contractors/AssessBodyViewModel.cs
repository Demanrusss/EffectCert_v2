using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewModels.Contractors
{
    public class AssessBodyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public AddressViewModel Address { get; set; } = null!;
        public ContractorLegalViewModel ContractorLegal { get; set; } = null!;
        public AttestateViewModel Attestate { get; set; } = null!;
        public ICollection<AssessBodyEmployeeViewModel> AssessBodyEmployees { get; set; } = new List<AssessBodyEmployeeViewModel>();
    }
}
