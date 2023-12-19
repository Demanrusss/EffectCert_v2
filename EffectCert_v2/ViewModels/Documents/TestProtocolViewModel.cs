using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.ViewModels.Documents
{
    public class TestProtocolViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Номер")]
        public string Number { get; set; } = null!;
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Дата")]
        public DateTime Date { get; set; }
        [DisplayName("Лаборатория")]
        public LaboratoryViewModel? Laboratory { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int LaboratoryId { get; set; }
    }
}
