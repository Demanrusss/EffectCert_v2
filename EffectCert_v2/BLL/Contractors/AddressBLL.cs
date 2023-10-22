using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.BLL;
using Microsoft.IdentityModel.Tokens;

namespace EffectCert.BLL.Contractors
{
    public class AddressBLL : ICommonBLL<Address>
    {
        private readonly AddressRepo addressDAL;

        public AddressBLL(AddressRepo addressDAL)
        {
            this.addressDAL = addressDAL;
        }

        public async Task<Address> Get(int id)
        {
            return await addressDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(Address address)
        {
            return address.Id == 0 
                ? await addressDAL.Create(address) 
                : await addressDAL.Update(address);
        }

        public async Task<ICollection<Address>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await addressDAL.Find(searchStr);
        }

        public async Task<ICollection<Address>> FindAll()
        {
            return await addressDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await addressDAL.Delete(id);
        }
    }
}
