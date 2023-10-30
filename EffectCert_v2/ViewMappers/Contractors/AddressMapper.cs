using EffectCert.DAL.Entities.Contractors;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.ViewMappers.Contractors
{
    public static class AddressMapper
    {
        public static Address MapToModel(AddressViewModel addressViewModel)
        {
            return new Address()
            {
                Id = addressViewModel.Id,
                Country = addressViewModel.Country,
                Index = addressViewModel.Index,
                AddressStr = addressViewModel.AddressLine
            };
        }

        public static AddressViewModel MapToViewModel(Address address)
        {
            return new AddressViewModel()
            {
                Id = address.Id,
                Country = address.Country,
                Index = address.Index,
                AddressLine = address.AddressStr
            };
        }
    }
}
