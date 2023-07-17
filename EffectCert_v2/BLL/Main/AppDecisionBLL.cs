using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Implementations.Main;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using Microsoft.IdentityModel.Tokens;

namespace EffectCert.BLL.Main
{
    public class AppDecisionBLL : ICommonBLL<AppDecision>
    {
        private readonly AppDecisionRepo appDecisionDAL;

        public AppDecisionBLL (AppDecisionRepo appDecisionDAL)
        {
            this.appDecisionDAL = appDecisionDAL;
        }

        public async Task<AppDecision> Get(int id)
        {
            return await appDecisionDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(AppDecision appDecision)
        {
            return appDecision.Id == 0 
                ? await appDecisionDAL.Create(appDecision) 
                : await appDecisionDAL.Update(appDecision);
        }

        public async Task<IEnumerable<AppDecision>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await appDecisionDAL.Find(searchStr);
        }

        public async Task<IEnumerable<AppDecision>> FindAll()
        {
            return await appDecisionDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await appDecisionDAL.Delete(id);
        }
    }
}
