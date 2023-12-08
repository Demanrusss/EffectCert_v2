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
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Заявка")]
        public ApplicationViewModel? Application { get; set; }
        public int ApplicationId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Решение по заявке")]
        public AppDecisionViewModel? Decision { get; set; }
        public int DecisionId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Акт отбора образцов")]
        public SelectProductsActViewModel? SelectProductsAct { get; set; }
        public int SelectProductsActId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Экспертное решение")]
        public ExpertDecisionViewModel? ExpertDecision { get; set; }
        public int ExpertDecisionId { get; set; }
    }
}
