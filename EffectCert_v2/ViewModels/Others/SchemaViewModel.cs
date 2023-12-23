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
        [DisplayName("Объекты подтверждения соответствия")]
        public ICollection<CertObjectViewModel> CertObjects { get; set; } = new HashSet<CertObjectViewModel>();
        public int[]? CertObjectIds { get; set; }
    }
}
