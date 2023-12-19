using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.ViewModels.Main
{
    public class ActionPlanViewModel
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
        [DisplayName("Эксперт-аудитор по анализу заявки")]
        public AssessBodyEmployeeViewModel? AppAnalizeExpert { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int AppAnalizeExpertId { get; set; }
        [DisplayName("Руководитель ОПС")]
        public AssessBodyEmployeeViewModel? ConformityAssessBodyHead { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int ConformityAssessBodyHeadId { get; set; }
        [DisplayName("Ответственный по отбору продукции")]
        public ContractorLegalEmployeeViewModel? SelectProductEmployee { get; set; }
        public int? SelectProductEmployeeId { get; set; }
        [DisplayName("Эксперт-аудитор по анализу результатов")]
        public AssessBodyEmployeeViewModel? ResultsAnalizeExpert { get; set; }
        public int? ResultsAnalizeExpertId { get; set; }
        [DisplayName("Ответственный по регистрации выходного документа")]
        public AssessBodyEmployeeViewModel? RegDocumentEmployee { get; set; }
        public int? RegDocumentEmployeeId { get; set; }
    }
}
