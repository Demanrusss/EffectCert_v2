using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Implementations.Main;
using EffectCert.BLL;

namespace EffectCert.BLL.Main
{
    public class IssueDecisionBLL : ICommonBLL<IssueDecision>
    {
        private readonly IssueDecisionRepo issueDecisionDAL;

        public IssueDecisionBLL (IssueDecisionRepo issueDecisionDAL)
        {
            this.issueDecisionDAL = issueDecisionDAL;
        }

        public async Task<IssueDecision> Get(int id)
        {
            return await issueDecisionDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(IssueDecision issueDecision)
        {
            return issueDecision.Id == 0 
                ? await issueDecisionDAL.Create(issueDecision) 
                : await issueDecisionDAL.Update(issueDecision);
        }

        public async Task<IEnumerable<IssueDecision>> Find(string searchStr)
        {
            return await issueDecisionDAL.Find(searchStr);
        }
    }
}
