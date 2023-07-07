using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Implementations.Main;
using EffectCert.BLL;

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
            return await appDecisionDAL.Find(searchStr);
        }
    }
}
