using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using Microsoft.IdentityModel.Tokens;

namespace EffectCert.BLL.Documents
{
    public class GovStandardBLL : ICommonBLL<GovStandard>
    {
        private readonly GovStandardRepo govStandardDAL;

        public GovStandardBLL(GovStandardRepo govStandardDAL)
        {
            this.govStandardDAL = govStandardDAL;
        }

        public async Task<GovStandard> Get(int id)
        {
            return await govStandardDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(GovStandard govStandard)
        {
            return govStandard.Id == 0 
                ? await govStandardDAL.Create(govStandard) 
                : await govStandardDAL.Update(govStandard);
        }

        public async Task<IEnumerable<GovStandard>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await govStandardDAL.Find(searchStr);
        }

        public async Task<IEnumerable<GovStandard>> FindAll()
        {
            return await govStandardDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await govStandardDAL.Delete(id);
        }
    }
}
