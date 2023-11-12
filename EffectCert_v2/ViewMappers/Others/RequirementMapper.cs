using EffectCert.DAL.Entities.Others;
using EffectCert.ViewModels.Others;

namespace EffectCert.ViewMappers.Others
{
    public static class RequirementMapper
    {
        public static Requirement MapToModel(RequirementViewModel viewModel)
        {
            return new Requirement()
            {
                Id = viewModel.Id,
                Name = viewModel.Name
            };
        }

        public static RequirementViewModel MapToViewModel(Requirement model)
        {
            if (model == null)
                return new RequirementViewModel();

            return new RequirementViewModel()
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
