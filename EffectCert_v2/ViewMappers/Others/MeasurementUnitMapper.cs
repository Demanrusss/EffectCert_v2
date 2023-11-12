using EffectCert.DAL.Entities.Others;
using EffectCert.ViewModels.Others;

namespace EffectCert.ViewMappers.Others
{
    public static class MeasurementUnitMapper
    {
        public static MeasurementUnit MapToModel(MeasurementUnitViewModel viewModel)
        {
            return new MeasurementUnit()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                ShortName = viewModel.ShortName
            };
        }

        public static MeasurementUnitViewModel MapToViewModel(MeasurementUnit model)
        {
            if (model == null)
                return new MeasurementUnitViewModel();

            return new MeasurementUnitViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                ShortName = model.ShortName
            };
        }
    }
}
