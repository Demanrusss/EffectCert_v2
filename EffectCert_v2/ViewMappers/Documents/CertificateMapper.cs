using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewMappers.Documents
{
    public static class CertificateMapper
    {
        public static Certificate MapToModel(CertificateViewModel viewModel)
        {
            return new Certificate()
            {
                Id = viewModel.Id,
                Date = viewModel.Date,
                Number = viewModel.Number,
                ValidDate = viewModel.ValidDate
            };
        }

        public static CertificateViewModel MapToViewModel(Certificate model)
        {
            if (model == null)
                return new CertificateViewModel();

            return new CertificateViewModel()
            {
                Id = model.Id,
                Date = model.Date,
                Number = model.Number,
                ValidDate = model.ValidDate
            };
        }
    }
}
