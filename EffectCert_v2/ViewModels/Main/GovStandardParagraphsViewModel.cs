using EffectCert.ViewModels.Documents;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EffectCert.ViewModels.Main
{
    public class GovStandardParagraphsViewModel
    {
        [DisplayName("ГОСТ")]
        public GovStandardViewModel? GovStandard { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")] 
        public int GovStandardId { get; set; }
        [DisplayName("Разделы, пункты, абзацы, и т.п.")]
        public string? Paragraphs { get; set; }
    }
}
