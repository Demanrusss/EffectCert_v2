using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewModels.Main
{
    public class ExpertDecisionViewModel
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
        [DisplayName("Информация о знаке соответствия")]
        public string? ConformityMarkInfo { get; set; }
        [DisplayName("Эксперт-аудитор")]
        public AssessBodyEmployeeViewModel? Expert { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int ExpertId { get; set; }
        [DisplayName("Действует до")]
        public DateTime? ValidDate { get; set; }
        [DisplayName("Эксперт-аудитор по анализу документов")]
        public AssessBodyEmployeeViewModel? DocsAnalizeExpert { get; set; }
        public int? DocsAnalizeExpertId { get; set; }
        [DisplayName("Дата подписания")]
        public DateTime? DocsAnalizeExpertSignDate { get; set; }
        [DisplayName("Протоколы испытаний")]
        public ICollection<TestProtocolViewModel> TestProtocols { get; set; } = new HashSet<TestProtocolViewModel>();
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int[]? TestProtocolsIds { get; set; }
    }
}
