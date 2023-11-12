using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EffectCert.ViewModels.Others
{
    public class ProductQuantityViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Продукция")]
        public ProductViewModel Product { get; set; } = null!;
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Количество")]
        public double Quantity { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Единицы измерения")]
        public MeasurementUnitViewModel MeasurementUnit { get; set; } = null!;
        public int MeasurementUnitId { get; set; }
        [Required(ErrorMessage = "Данное поле должно быть заполнено!")]
        [DisplayName("Дата изготовления")]
        public DateTime MadeDate { get; set; }
    }
}
