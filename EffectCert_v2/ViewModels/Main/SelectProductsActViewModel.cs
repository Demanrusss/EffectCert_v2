using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewModels.Others;

namespace EffectCert.ViewModels.Main
{
    public class SelectProductsActViewModel
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
        [DisplayName("План действий")]
        public ActionPlanViewModel? ActionPlan { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int ActionPlanId { get; set; }
        [DisplayName("Адрес отбора")]
        public AddressViewModel? Address { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int AddressId { get; set; }
        [DisplayName("Поставщик")]
        public ContractorLegalViewModel? Supplier { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int SupplierId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Условия хранения")]
        public string StorageCondition { get; set; } = null!;
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Тип упаковки")]
        public string PackageType { get; set; } = null!;
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Срок хранения контрольных образцов продукции")]
        public int ControlSamplesStorageTime { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Количество контрольных образцов продукции")]
        public string ControlSamplesQuantity { get; set; } = null!;
        [DisplayName("Отобранные образцы продукции")]
        public ICollection<SelectedSampleQuantityViewModel> SelectedProducts { get; set; } = new HashSet<SelectedSampleQuantityViewModel>();
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int[]? SelectedProductsIds { get; set; }
    }
}
