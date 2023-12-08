using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewModels.Main
{
    public class IssueDecisionViewModel
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
        [DisplayName("Сертификат")]
        public CertificateViewModel? Certificate { get; set; }
        public int? CertificateId { get; set; }
        [DisplayName("Декларация")]
        public DeclarationViewModel? Declaration { get; set; }
        public int? DeclarationId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Экспертное заключение")]
        public ExpertDecisionViewModel? ExpertDecision { get; set; }
        public int ExpertDecisionId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Рекомендация")]
        public RecommendationViewModel? Recommendation { get; set; }
        public int RecommendationId { get; set; }
    }
}
