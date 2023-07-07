using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Implementations.Main;
using EffectCert.BLL;

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

        public async Task<IEnumerable<ExpertDecision>> Find(string searchStr)
        {
            return await expertDecisionDAL.Find(searchStr);
        }
    }
}
