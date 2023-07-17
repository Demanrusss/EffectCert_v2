using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EffectCert.ViewModels.Contractors
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Страна")]
        public string Country { get; set; } = null!;
        [DisplayName("Индекс")]
        public string? Index { get; set; }
        [DisplayName("Строка адреса")]
        public string? AddressLine { get; set; }
    }
}
