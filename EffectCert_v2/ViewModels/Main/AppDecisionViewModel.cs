using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewModels.Others;

namespace EffectCert.ViewModels.Main
{
    public class AppDecisionViewModel
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
        [DisplayName("План действий")]
        public ActionPlanViewModel? ActionPlan { get; set; }
        public int ActionPlanId { get; set; }
        [DisplayName("ОПС по анализу производства")]
        public AssessBodyViewModel? ProductionAnalyzeAssessBody { get; set; }
        public int? ProductionAnalyzeAssessBodyId { get; set; }
        [DisplayName("Лаборатория по анализу производства")]
        public LaboratoryViewModel? ProductionAnalyzeLaboratory { get; set; }
        public int? ProductionAnalyzeLaboratoryId { get; set; }
        [DisplayName("ОПС по инспекционному контролю производства")]
        public AssessBodyViewModel? InspectionAssessBody { get; set; }
        public int? InspectionAssessBodyId { get; set; }
        [DisplayName("Лаборатория по инспекционному контролю производства")]
        public LaboratoryViewModel? InspectionLaboratory { get; set; }
        public int? InspectionLaboratoryId { get; set; }
        [DisplayName("Периодичность инспекционного контроля")]
        public string? InspectionPeriod { get; set; }
        [DisplayName("Другая схема")]
        public SchemaViewModel? SchemaAnother { get; set; }
        public int? SchemaAnotherId { get; set; }
        [DisplayName("Номер декларации")]
        public string? DeclarationNumber { get; set; }
        [DisplayName("Дата декларации")]
        public DateTime? DeclarationDate { get; set; }
        [DisplayName("Номер договора на подтверждение соответствия")]
        public string? AssessContractNumber { get; set; }
        [DisplayName("Дата договора на подтверждение соответствия")]
        public DateTime? AssessContractDate { get; set; }
    }
}
