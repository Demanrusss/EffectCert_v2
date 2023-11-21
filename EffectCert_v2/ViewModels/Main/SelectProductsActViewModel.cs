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
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Заявка")]
        public ApplicationViewModel Application { get; set; } = null!;
        public int ApplicationId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("План действий")]
        public ActionPlanViewModel ActionPlan { get; set; } = null!;
        public int ActionPlanId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Адрес отбора")]
        public AddressViewModel Address { get; set; } = null!;
        public int AddressId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Поставщик")]
        public ContractorLegalViewModel Supplier { get; set; } = null!;
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
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Отобранные образцы продукции")]
        public ICollection<SelectedSampleQuantityViewModel> SelectedProducts { get; set; } = new HashSet<SelectedSampleQuantityViewModel>();
    }
}
