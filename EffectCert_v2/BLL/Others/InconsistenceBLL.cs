using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using Microsoft.IdentityModel.Tokens;

namespace EffectCert.BLL.Others
{
    public class InconsistenceBLL : ICommonBLL<Inconsistence>
    {
        private readonly InconsistenceRepo inconsistenceDAL;

        public InconsistenceBLL(InconsistenceRepo inconsistenceDAL)
        {
            this.inconsistenceDAL = inconsistenceDAL;
        }

        public async Task<Inconsistence> Get(int id)
        {
            return await inconsistenceDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(Inconsistence inconsistence)
        {
            return inconsistence.Id == 0
                ? await inconsistenceDAL.Create(inconsistence)
                : await inconsistenceDAL.Update(inconsistence);
        }

        public async Task<ICollection<Inconsistence>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await inconsistenceDAL.Find(searchStr);
        }

        public async Task<ICollection<Inconsistence>> FindAll()
        {
            return await inconsistenceDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await inconsistenceDAL.Delete(id);
        }
    }
}
