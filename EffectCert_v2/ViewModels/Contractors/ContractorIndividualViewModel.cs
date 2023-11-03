using System.ComponentModel;

namespace EffectCert.ViewModels.Contractors
{
    public class ContractorIndividualViewModel
    {
        public int Id { get; set; }
        [DisplayName("Фамилия")]
        public string LastName { get; set; } = null!;
        [DisplayName("Имя")]
        public string FirstName { get; set; } = null!;
        [DisplayName("Отчество")]
        public string? MiddleName { get; set; }
        [DisplayName("ИИН")]
        public string? IIN { get; set; }
    }
}
