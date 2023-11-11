using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Main
{
    public class IssueDecisionRepo : IRepository<IssueDecision>
    {
        private readonly AppDBContext appDBContext;

        public IssueDecisionRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<IssueDecision>> GetAll()
        {
            return await appDBContext.IssueDecisions.ToListAsync();
        }

        public async Task<IssueDecision> Get(int id)
        {
            return await appDBContext.IssueDecisions.FirstOrDefaultAsync(a => a.Id == id) ?? new IssueDecision();
        }

        public async Task<ICollection<IssueDecision>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            var result = appDBContext.IssueDecisions.Where(c => c.Number.Contains(searchStr));

            return await result.ToListAsync();
        }

        public async Task<int> Create(IssueDecision issueDecision)
        {
            if (issueDecision == null)
                throw new ArgumentNullException();

            appDBContext.IssueDecisions.Add(issueDecision);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(IssueDecision issueDecision)
        {
            if (issueDecision == null)
                return 0;

            appDBContext.IssueDecisions.Update(issueDecision);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            IssueDecision? issueDecision = await appDBContext.IssueDecisions.FindAsync(id);
            if (issueDecision == null)
                return 0;

            appDBContext.IssueDecisions.Remove(issueDecision);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
