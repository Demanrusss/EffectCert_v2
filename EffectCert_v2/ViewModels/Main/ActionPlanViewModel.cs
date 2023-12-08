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
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Заявка")]
        public ApplicationViewModel? Application { get; set; }
        public int ApplicationId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Эксперт-аудитор по анализу заявки")]
        public AssessBodyEmployeeViewModel? AppAnalizeExpert { get; set; }
        public int AppAnalizeExpertId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Руководитель ОПС")]
        public AssessBodyEmployeeViewModel? ConformityAssessBodyHead { get; set; }
        public int ConformityAssessBodyHeadId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Ответственный по отбору продукции")]
        public ContractorLegalEmployeeViewModel? SelectProductEmployee { get; set; }
        public int? SelectProductEmployeeId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Эксперт-аудитор по анализу результатов")]
        public AssessBodyEmployeeViewModel? ResultsAnalizeExpert { get; set; }
        public int? ResultsAnalizeExpertId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Ответственный по регистрации выходного документа")]
        public AssessBodyEmployeeViewModel? RegDocumentEmployee { get; set; }
        public int? RegDocumentEmployeeId { get; set; }
    }
}
