using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Main
{
    public class AppDecisionRepo : IRepository<AppDecision>
    {
        private readonly AppDBContext appDBContext;

        public AppDecisionRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<AppDecision>> GetAll()
        {
            return await appDBContext.AppDecisions.ToListAsync();
        }

        public async Task<AppDecision> Get(int id)
        {
            return await appDBContext.AppDecisions.FirstOrDefaultAsync(a => a.Id == id) ?? new AppDecision();
        }

        public async Task<ICollection<AppDecision>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            var result = appDBContext.AppDecisions.Where(c => c.Number.Contains(searchStr));

            return await result.ToListAsync();
        }

        public async Task<int> Create(AppDecision appDecision)
        {
            if (appDecision == null)
                throw new ArgumentNullException();

            appDBContext.AppDecisions.Add(appDecision);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(AppDecision appDecision)
        {
            if (appDecision == null)
                return 0;

            appDBContext.AppDecisions.Update(appDecision);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            AppDecision? appDecision = await appDBContext.AppDecisions.FindAsync(id);
            if (appDecision == null)
                return 0;

            appDBContext.AppDecisions.Remove(appDecision);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
