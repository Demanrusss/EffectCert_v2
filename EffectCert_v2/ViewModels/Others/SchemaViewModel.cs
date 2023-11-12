using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EffectCert.ViewModels.Others
{
    public class SchemaViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Номер")]
        public string Name { get; set; } = null!;
    }
}
