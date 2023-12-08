using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewModels.Others;

namespace EffectCert.ViewModels.Main
{
    public class ApplicationViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Номер")]
        public string Number { get; set; } = null!;
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Дата")]
        public DateTime Date { get; set; }
        public int AssessBodyId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Орган подтверждения соответствия")]
        public AssessBodyViewModel? AssessBody { get; set; }
        public int ContractorLegalId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Заявитель")]
        public ContractorLegalViewModel? ContractorLegal { get; set; }
        [DisplayName("Номер в электронном реестре")]
        public string? ElectronicNumber { get; set; }
        [DisplayName("Дата в электронном реестре")]
        public DateTime? ElectronicDate { get; set; }
        public int SchemaId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Схема подтверждения соответствия")]
        public SchemaViewModel Schema { get; set; } = null!;
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Продукция")]
        public ICollection<ProductViewModel> Products { get; set; } = new HashSet<ProductViewModel>();
    }
}
