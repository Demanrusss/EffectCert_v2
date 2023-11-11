using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewMappers.Documents
{
    public static class AttestateMapper
    {
        public static Attestate MapToModel(AttestateViewModel viewModel)
        {
            return new Attestate()
            {
                Id = viewModel.Id,
                Date = viewModel.Date,
                Number = viewModel.Number,
                ValidDate = viewModel.ValidDate
            };
        }

        public static AttestateViewModel MapToViewModel(Attestate model)
        {
            if (model == null)
                return new AttestateViewModel();

            return new AttestateViewModel()
            {
                Id = model.Id,
                Date = model.Date,
                Number = model.Number,
                ValidDate = model.ValidDate
            };
        }
    }
}
