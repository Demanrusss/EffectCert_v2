using EffectCert.DAL.Entities.Others;
using EffectCert.ViewModels.Others;

namespace EffectCert.ViewMappers.Others
{
    public static class CertObjectMapper
    {
        public static CertObject MapToModel(CertObjectViewModel viewModel)
        {
            return new CertObject()
            {
                Id = viewModel.Id,
                Name = viewModel.Name
            };
        }

        public static CertObjectViewModel MapToViewModel(CertObject model)
        {
            if (model == null)
                return new CertObjectViewModel();

            return new CertObjectViewModel()
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
