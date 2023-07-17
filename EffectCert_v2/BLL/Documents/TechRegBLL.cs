using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using Microsoft.IdentityModel.Tokens;

namespace EffectCert.BLL.Documents
{
    public class TechRegBLL : ICommonBLL<TechReg>
    {
        private readonly TechRegRepo techRegDAL;

        public TechRegBLL (TechRegRepo techRegDAL)
        {
            this.techRegDAL = techRegDAL;
        }

        public async Task<TechReg> Get(int id)
        {
            return await techRegDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(TechReg techReg)
        {
            return techReg.Id == 0 
                ? await techRegDAL.Create(techReg) 
                : await techRegDAL.Update(techReg);
        }

        public async Task<IEnumerable<TechReg>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();
            
            return await techRegDAL.Find(searchStr);
        }

        public async Task<IEnumerable<TechReg>> FindAll()
        {
            return await techRegDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await techRegDAL.Delete(id);
        }
    }
}
