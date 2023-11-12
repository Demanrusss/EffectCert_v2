using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.ViewModels.Others
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Наименование")]
        public string Name { get; set; } = null!;
        public string? GroupName { get; set; }
        public string? Type { get; set; }
        public string? TradeMark { get; set; }
        public string? Model { get; set; }
        public string? Article { get; set; }
        public int ManufacturerId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Изготовитель")]
        public ContractorLegalViewModel Manufacturer { get; set; } = null!;
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Код ТН ВЭД")]
        public string TNVED { get; set; } = null!;
    }
}
