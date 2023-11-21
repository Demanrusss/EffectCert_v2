using EffectCert.DAL.Entities.Others;
using EffectCert.ViewModels.Others;

namespace EffectCert.ViewMappers.Others
{
    public static class SelectedSampleQuantityMapper
    {
        public static SelectedSampleQuantity MapToModel(SelectedSampleQuantityViewModel viewModel)
        {
            return new SelectedSampleQuantity()
            {
                Id = viewModel.Id,
                MeasurementUnitId = viewModel.MeasurementUnitId,
                ProductQuantityId = viewModel.ProductQuantityId,
                Quantity = viewModel.Quantity
            };
        }

        public static SelectedSampleQuantityViewModel MapToViewModel(SelectedSampleQuantity model)
        {
            if (model == null)
                return new SelectedSampleQuantityViewModel();

            return new SelectedSampleQuantityViewModel()
            {
                Id = model.Id,
                MeasurementUnit = MeasurementUnitMapper.MapToViewModel(model.MeasurementUnit),
                ProductQuantity = ProductQuantityMapper.MapToViewModel(model.ProductQuantity),
                Quantity = model.Quantity
            };
        }
    }
}
