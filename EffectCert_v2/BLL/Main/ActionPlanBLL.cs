using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Implementations.Main;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using Microsoft.IdentityModel.Tokens;

namespace EffectCert.BLL.Main
{
    public class ActionPlanBLL : ICommonBLL<ActionPlan>
    {
        private readonly ActionPlanRepo actionPlanDAL;

        public ActionPlanBLL (ActionPlanRepo testProtocolDAL)
        {
            this.actionPlanDAL = testProtocolDAL;
        }

        public async Task<ActionPlan> Get(int id)
        {
            return await actionPlanDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(ActionPlan actionPlan)
        {
            return actionPlan.Id == 0 
                ? await actionPlanDAL.Create(actionPlan) 
                : await actionPlanDAL.Update(actionPlan);
        }

        public async Task<IEnumerable<ActionPlan>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await actionPlanDAL.Find(searchStr);
        }

        public async Task<IEnumerable<ActionPlan>> FindAll()
        {
            return await actionPlanDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await actionPlanDAL.Delete(id);
        }
    }
}
