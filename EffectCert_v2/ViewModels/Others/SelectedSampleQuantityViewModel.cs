using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EffectCert.ViewModels.Others
{
    public class SelectedSampleQuantityViewModel
    {
        public int Id { get; set; }
        [DisplayName("Продукция")]
        public ProductQuantityViewModel? ProductQuantity { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int ProductQuantityId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Количество отобранных образцов")]
        public double Quantity { get; set; }
        [DisplayName("Единицы измерения")]
        public MeasurementUnitViewModel? MeasurementUnit { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int MeasurementUnitId { get; set; }
    }
}
