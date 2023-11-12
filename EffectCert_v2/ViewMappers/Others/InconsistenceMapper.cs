using EffectCert.DAL.Entities.Others;
using EffectCert.ViewModels.Others;

namespace EffectCert.ViewMappers.Others
{
    public static class InconsistenceMapper
    {
        public static Inconsistence MapToModel(InconsistenceViewModel viewModel)
        {
            return new Inconsistence()
            {
                Id = viewModel.Id,
                Name = viewModel.Name
            };
        }

        public static InconsistenceViewModel MapToViewModel(Inconsistence model)
        {
            if (model == null)
                return new InconsistenceViewModel();

            return new InconsistenceViewModel()
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
