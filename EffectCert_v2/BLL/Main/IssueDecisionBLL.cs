using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Implementations.Main;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using Microsoft.IdentityModel.Tokens;

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

        public async Task<ICollection<IssueDecision>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await issueDecisionDAL.Find(searchStr);
        }

        public async Task<ICollection<IssueDecision>> FindAll()
        {
            return await issueDecisionDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await issueDecisionDAL.Delete(id);
        }
    }
}
