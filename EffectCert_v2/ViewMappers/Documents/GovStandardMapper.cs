using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewModels.Contractors;
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
                Number = viewModel.Number,
                Paragraphs = viewModel.Paragraphs
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
                Number = model.Number,
                Paragraphs = model.Paragraphs
            };
        }
    }
}
