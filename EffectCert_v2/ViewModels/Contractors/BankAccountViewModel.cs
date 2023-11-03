using System.ComponentModel;

namespace EffectCert.ViewModels.Contractors
{
    public class BankAccountViewModel
    {
        public int Id { get; set; }
        [DisplayName("ИИК")]
        public string IIK { get; set; } = null!;
        [DisplayName("Наименование банка")]
        public string BankName { get; set; } = null!;
        [DisplayName("БИК")]
        public string BIK { get; set; } = null!;
    }
}
