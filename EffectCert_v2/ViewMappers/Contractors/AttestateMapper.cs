using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewMappers.Contractors
{
    public static class AttestateMapper
    {
        public static Attestate MapToModel(AttestateViewModel attestateViewModel)
        {
            return new Attestate()
            {
                Id = attestateViewModel.Id,
                Date = attestateViewModel.Date,
                Number = attestateViewModel.Number,
                ValidDate = attestateViewModel.ValidDate
            };
        }

        public static AttestateViewModel MapToViewModel(Attestate attestate)
        {
            if (attestate == null)
                return new AttestateViewModel();

            return new AttestateViewModel()
            {
                Id = attestate.Id,
                Date = attestate.Date,
                Number = attestate.Number,
                ValidDate = attestate.ValidDate
            };
        }
    }
}
