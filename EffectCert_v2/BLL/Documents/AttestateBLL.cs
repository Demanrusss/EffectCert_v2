using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using Microsoft.IdentityModel.Tokens;

namespace EffectCert.BLL.Documents
{
    public class AttestateBLL : ICommonBLL<Attestate>
    {
        private readonly AttestateRepo attestateDAL;

        public AttestateBLL(AttestateRepo attestateDAL)
        {
            this.attestateDAL = attestateDAL;
        }

        public async Task<Attestate> Get(int id)
        {
            return await attestateDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(Attestate attestate)
        {
            return attestate.Id == 0 
                ? await attestateDAL.Create(attestate) 
                : await attestateDAL.Update(attestate);
        }

        public async Task<ICollection<Attestate>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await attestateDAL.Find(searchStr);
        }

        public async Task<ICollection<Attestate>> FindAll()
        {
            return await attestateDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await attestateDAL.Delete(id);
        }
    }
}
