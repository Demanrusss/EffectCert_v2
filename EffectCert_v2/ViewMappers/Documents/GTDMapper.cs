using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewMappers.Documents
{
    public static class GTDMapper
    {
        public static GTD MapToModel(GTDViewModel viewModel)
        {
            return new GTD()
            {
                Id = viewModel.Id,
                Date = viewModel.Date,
                Number = viewModel.Number
            };
        }

        public static GTDViewModel MapToViewModel(GTD model)
        {
            if (model == null)
                return new GTDViewModel();

            return new GTDViewModel()
            {
                Id = model.Id,
                Date = model.Date,
                Number = model.Number
            };
        }
    }
}
