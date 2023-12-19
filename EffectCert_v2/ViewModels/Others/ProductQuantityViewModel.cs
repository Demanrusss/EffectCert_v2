using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EffectCert.ViewModels.Others
{
    public class ProductQuantityViewModel
    {
        public int Id { get; set; }
        [DisplayName("Продукция")]
        public ProductViewModel? Product { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Количество")]
        public double Quantity { get; set; }
        [DisplayName("Единицы измерения")]
        public MeasurementUnitViewModel? MeasurementUnit { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        public int MeasurementUnitId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Дата изготовления")]
        public DateTime MadeDate { get; set; }
    }
}
