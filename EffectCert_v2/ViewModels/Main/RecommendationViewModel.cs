using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EffectCert.ViewModels.Main
{
    public class RecommendationViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Номер")]
        public string Number { get; set; } = null!;
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Дата")]
        public DateTime Date { get; set; }
        [DisplayName("Заявка")]
        public ApplicationViewModel? Application { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int ApplicationId { get; set; }
        [DisplayName("Решение по заявке")]
        public AppDecisionViewModel? Decision { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int DecisionId { get; set; }
        [DisplayName("Акт отбора образцов")]
        public SelectProductsActViewModel? SelectProductsAct { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int SelectProductsActId { get; set; }
        [DisplayName("Экспертное решение")]
        public ExpertDecisionViewModel? ExpertDecision { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int ExpertDecisionId { get; set; }
    }
}
