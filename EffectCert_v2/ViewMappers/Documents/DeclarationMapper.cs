using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewMappers.Documents
{
    public static class DeclarationMapper
    {
        public static Declaration MapToModel(DeclarationViewModel viewModel)
        {
            return new Declaration()
            {
                Id = viewModel.Id,
                Date = viewModel.Date,
                Number = viewModel.Number,
                ValidDate = viewModel.ValidDate
            };
        }

        public static DeclarationViewModel MapToViewModel(Declaration model)
        {
            if (model == null)
                return new DeclarationViewModel();

            return new DeclarationViewModel()
            {
                Id = model.Id,
                Date = model.Date,
                Number = model.Number,
                ValidDate = model.ValidDate
            };
        }
    }
}
