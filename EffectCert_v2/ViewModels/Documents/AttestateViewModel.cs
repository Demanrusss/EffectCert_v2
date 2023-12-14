using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EffectCert.ViewModels.Documents
{
    public class AttestateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Номер")]
        [RegularExpression("[A-Z]{2}.[A-Z]{1}.[0-9]{2}.[0-9]{4}", ErrorMessage = "Формат должен соответствовать XX.X.00.0000")]
        public string Number { get; set; } = null!;
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Дата регистрации")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Действителен до")]
        public DateTime ValidDate { get; set; }
    }
}
