using EffectCert.DAL.Entities.Others;
using EffectCert.ViewModels.Others;

namespace EffectCert.ViewMappers.Others
{
    public static class ProductQuantityMapper
    {
        public static ProductQuantity MapToModel(ProductQuantityViewModel viewModel)
        {
            return new ProductQuantity()
            {
                Id = viewModel.Id,
                MadeDate = viewModel.MadeDate,
                MeasurementUnitId = viewModel.MeasurementUnitId,
                ProductId = viewModel.ProductId,
                Quantity = viewModel.Quantity
            };
        }

        public static ProductQuantityViewModel MapToViewModel(ProductQuantity model)
        {
            if (model == null)
                return new ProductQuantityViewModel();

            return new ProductQuantityViewModel()
            {
                Id = model.Id,
                MadeDate = model.MadeDate,
                MeasurementUnit = MeasurementUnitMapper.MapToViewModel(model.MeasurementUnit),
                Product = ProductMapper.MapToViewModel(model.Product),
                Quantity = model.Quantity
            };
        }
    }
}
