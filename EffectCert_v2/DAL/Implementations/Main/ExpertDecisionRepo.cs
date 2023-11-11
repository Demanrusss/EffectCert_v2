using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Main
{
    public class ExpertDecisionRepo : IRepository<ExpertDecision>
    {
        private readonly AppDBContext appDBContext;

        public ExpertDecisionRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<ExpertDecision>> GetAll()
        {
            return await appDBContext.ExpertDecisions.ToListAsync();
        }

        public async Task<ExpertDecision> Get(int id)
        {
            return await appDBContext.ExpertDecisions.FirstOrDefaultAsync(a => a.Id == id) ?? new ExpertDecision();
        }

        public async Task<ICollection<ExpertDecision>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            var result = appDBContext.ExpertDecisions.Where(c => c.Number.Contains(searchStr));

            return await result.ToListAsync();
        }

        public async Task<int> Create(ExpertDecision expertDecision)
        {
            if (expertDecision == null)
                throw new ArgumentNullException();

            appDBContext.ExpertDecisions.Add(expertDecision);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(ExpertDecision expertDecision)
        {
            if (expertDecision == null)
                return 0;

            appDBContext.ExpertDecisions.Update(expertDecision);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            ExpertDecision? expertDecision = await appDBContext.ExpertDecisions.FindAsync(id);
            if (expertDecision == null)
                return 0;

            appDBContext.ExpertDecisions.Remove(expertDecision);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
