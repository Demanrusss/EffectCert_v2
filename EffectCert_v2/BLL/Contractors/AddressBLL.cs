using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.BLL;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewMappers.Contractors;

namespace EffectCert.BLL.Contractors
{
    public class AddressBLL : ICommonBLL<AddressViewModel>
    {
        private readonly AddressRepo addressDAL;

        public AddressBLL(AddressRepo addressDAL)
        {
            this.addressDAL = addressDAL;
        }

        public async Task<AddressViewModel> Get(int id)
        {
            var address = await addressDAL.Get(id);

            return AddressMapper.MapAddressToAddressViewModel(address);
        }

        public async Task<int> UpdateOrCreate(AddressViewModel addressViewModel)
        {
            var address = AddressMapper.MapAddressViewModelToAddress(addressViewModel);

            return address.Id == 0 
                ? await addressDAL.Create(address) 
                : await addressDAL.Update(address);
        }

        public async Task<ICollection<AddressViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var addresses = await addressDAL.Find(searchStr);

            return ConvertAddressCollection(addresses);
        }

        public async Task<ICollection<AddressViewModel>> FindAll()
        {
            var addresses = await addressDAL.GetAll();

            return ConvertAddressCollection(addresses);
        }

        public async Task<int> Delete(int id)
        {
            return await addressDAL.Delete(id);
        }

        private ICollection<AddressViewModel> ConvertAddressCollection(ICollection<Address> addresses)
        {
            var addressesVM = new List<AddressViewModel>(addresses.Count);

            foreach (var address in addresses)
                addressesVM.Add(AddressMapper.MapAddressToAddressViewModel(address));

            return addressesVM;
        }
    }
}
