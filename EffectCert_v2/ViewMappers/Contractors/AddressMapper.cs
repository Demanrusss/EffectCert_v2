using EffectCert.DAL.Entities.Contractors;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.ViewMappers.Contractors
{
    public static class AddressMapper
    {
        public static Address MapAddressViewModelToAddress(AddressViewModel addressViewModel)
        {
            return new Address()
            {
                Id = addressViewModel.Id,
                Country = addressViewModel.Country,
                Index = addressViewModel.Index,
                AddressLine = addressViewModel.AddressLine
            };
        }

        public static AddressViewModel MapAddressToAddressViewModel(Address address)
        {
            return new AddressViewModel()
            {
                Id = address.Id,
                Country = address.Country,
                Index = address.Index,
                AddressLine = address.AddressLine
            };
        }
    }
}
