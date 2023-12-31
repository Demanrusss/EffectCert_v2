using EffectCert.ViewModels.Documents;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EffectCert.ViewModels.Main
{
    public class TechRegParagraphsViewModel
    {
        [DisplayName("Технический регламент")]
        public TechRegViewModel? TechReg { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int TechRegId { get; set; }
        [DisplayName("Разделы, пункты, абзацы, и т.п.")]
        public string? Paragraphs { get; set; }
    }
}
