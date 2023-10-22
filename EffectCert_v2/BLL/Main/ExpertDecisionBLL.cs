using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Implementations.Main;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using Microsoft.IdentityModel.Tokens;

namespace EffectCert.BLL.Main
{
    public class ExpertDecisionBLL : ICommonBLL<ExpertDecision>
    {
        private readonly ExpertDecisionRepo expertDecisionDAL;

        public ExpertDecisionBLL (ExpertDecisionRepo expertDecisionDAL)
        {
            this.expertDecisionDAL = expertDecisionDAL;
        }

        public async Task<ExpertDecision> Get(int id)
        {
            return await expertDecisionDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(ExpertDecision expertDecision)
        {
            return expertDecision.Id == 0 
                ? await expertDecisionDAL.Create(expertDecision) 
                : await expertDecisionDAL.Update(expertDecision);
        }

        public async Task<ICollection<ExpertDecision>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await expertDecisionDAL.Find(searchStr);
        }

        public async Task<ICollection<ExpertDecision>> FindAll()
        {
            return await expertDecisionDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await expertDecisionDAL.Delete(id);
        }
    }
}
