using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewMappers.Documents
{
    public static class ManufacturerStandardMapper
    {
        public static ManufacturerStandard MapToModel(ManufacturerStandardViewModel viewModel)
        {
            return new ManufacturerStandard()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Number = viewModel.Number,
                Date = viewModel.Date
            };
        }

        public static ManufacturerStandardViewModel MapToViewModel(ManufacturerStandard model)
        {
            if (model == null)
                return new ManufacturerStandardViewModel();

            return new ManufacturerStandardViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Number = model.Number,
                Date = model.Date
            };
        }
    }
}
