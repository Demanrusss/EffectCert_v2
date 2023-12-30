using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EffectCert.ViewModels.Documents
{
    public class TechRegViewModel
    {
        public int Id { get; set; }
        [DisplayName("Номер")]
        public string? Number { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Наименование")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Краткое наименование")]
        public string ShortName { get; set; } = null!;
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Утверждено (кем, когда, номер, дата)")]
        public string ApprovedByInfo { get; set; } = null!;
    }
}
