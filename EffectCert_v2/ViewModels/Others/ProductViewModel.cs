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
        [DisplayName("Группа")]
        public string? GroupName { get; set; }
        [DisplayName("Тип")]
        public string? Type { get; set; }
        [DisplayName("Торговая марка")]
        public string? TradeMark { get; set; }
        [DisplayName("Модель")]
        public string? Model { get; set; }
        [DisplayName("Артикул")]
        public string? Article { get; set; }
        public int ManufacturerId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Изготовитель")]
        public ContractorLegalViewModel? Manufacturer { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Код ТН ВЭД")]
        public string TNVED { get; set; } = null!;
    }
}
