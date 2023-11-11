using EffectCert.DAL.Entities.Contractors;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.ViewMappers.Contractors
{
    public static class AddressMapper
    {
        public static Address MapToModel(AddressViewModel viewModel)
        {
            return new Address()
            {
                Id = viewModel.Id,
                Country = viewModel.Country,
                Index = viewModel.Index,
                AddressStr = viewModel.AddressLine
            };
        }

        public static AddressViewModel MapToViewModel(Address model)
        {
            if (model == null)
                return new AddressViewModel();

            return new AddressViewModel()
            {
                Id = model.Id,
                Country = model.Country,
                Index = model.Index,
                AddressLine = model.AddressStr
            };
        }
    }
}
