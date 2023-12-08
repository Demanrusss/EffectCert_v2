using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewMappers.Contractors;
using EffectCert.BLL.Interfaces;
using EffectCert.ViewMappers;

namespace EffectCert.BLL.Contractors
{
    public class AddressBLL : IAddressBLL
    {
        private readonly AddressRepo addressDAL;

        public AddressBLL(AddressRepo addressDAL)
        {
            this.addressDAL = addressDAL;
        }

        public async Task<AddressViewModel> Get(int id)
        {
            var address = await addressDAL.Get(id);

            return AddressMapper.MapToViewModel(address);
        }

        public async Task<int> UpdateOrCreate(AddressViewModel addressVM)
        {
            var address = AddressMapper.MapToModel(addressVM);

            return address.Id == 0 
                ? await addressDAL.Create(address) 
                : await addressDAL.Update(address);
        }

        public async Task<ICollection<AddressViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var addresses = await addressDAL.Find(searchStr);

            return ConvertCollection(addresses);
        }

        public async Task<ICollection<AddressViewModel>> FindAll()
        {
            var addresses = await addressDAL.GetAll();

            return ConvertCollection(addresses);
        }

        public async Task<int> Delete(int id)
        {
            return await addressDAL.Delete(id);
        }

        private ICollection<AddressViewModel> ConvertCollection(ICollection<Address> collection)
        {
            var collectionVM = new List<AddressViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(AddressMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
