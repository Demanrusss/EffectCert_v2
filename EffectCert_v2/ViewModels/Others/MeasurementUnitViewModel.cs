using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EffectCert.ViewModels.Others
{
    public class MeasurementUnitViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Наименование")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Наименование")]
        public string ShortName { get; set; } = null!;
    }
}
