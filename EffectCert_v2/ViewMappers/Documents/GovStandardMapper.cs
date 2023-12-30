using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewMappers.Documents
{
    public static class GovStandardMapper
    {
        public static GovStandard MapToModel(GovStandardViewModel viewModel)
        {
            return new GovStandard()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Number = viewModel.Number
            };
        }

        public static GovStandardViewModel MapToViewModel(GovStandard model)
        {
            if (model == null)
                return new GovStandardViewModel();

            return new GovStandardViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Number = model.Number
            };
        }
    }
}
