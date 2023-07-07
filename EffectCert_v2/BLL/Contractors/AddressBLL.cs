using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.BLL;

namespace EffectCert.BLL.Contractors
{
    public class AttestateBLL : ICommonBLL<Address>
    {
        private readonly AddressRepo addressDAL;

        public AttestateBLL(AddressRepo addressDAL)
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

        public async Task<IEnumerable<Address>> Find(string searchStr)
        {
            return await addressDAL.Find(searchStr);
        }
    }
}
