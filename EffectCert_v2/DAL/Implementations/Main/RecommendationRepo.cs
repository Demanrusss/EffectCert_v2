using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Main
{
    public class RecommendationRepo : IRepository<Recommendation>
    {
        private readonly AppDBContext appDBContext;

        public RecommendationRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<Recommendation>> GetAll()
        {
            return await appDBContext.Recommendations
                .Include(r => r.Application)
                .Include(r => r.AppDecision)
                .Include(r => r.ExpertDecision)
                .Include(r => r.SelectProductsAct)
                .Select(r => new Recommendation
                {
                    Id = r.Id,
                    ApplicationId = r.ApplicationId,
                    Application = new Application
                    {
                        Number = r.Application.Number
                    },
                    SelectProductsActId = r.SelectProductsActId,
                    SelectProductsAct = new SelectProductsAct
                    {
                        Number = r.SelectProductsAct.Number
                    },
                    AppDecisionId = r.AppDecisionId,
                    AppDecision = new AppDecision
                    {
                        Number = r.AppDecision.Number
                    },
                    ExpertDecisionId = r.AppDecisionId,
                    ExpertDecision = new ExpertDecision
                    {
                        Number = r.AppDecision.Number
                    },
                    Date = r.Date,
                    Number = r.Number
                })
                .ToListAsync();
        }

        public async Task<Recommendation> Get(int id)
        {
            return await appDBContext.Recommendations.FirstOrDefaultAsync(a => a.Id == id) ?? new Recommendation();
        }

        public async Task<ICollection<Recommendation>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.Recommendations
                .Include(r => r.Application)
                .Include(r => r.AppDecision)
                .Include(r => r.ExpertDecision)
                .Include(r => r.SelectProductsAct)
                .Where(r => r.Number.Contains(searchStr))
                .Select(r => new Recommendation
                {
                    Id = r.Id,
                    ApplicationId = r.ApplicationId,
                    Application = new Application
                    {
                        Number = r.Application.Number
                    },
                    SelectProductsActId = r.SelectProductsActId,
                    SelectProductsAct = new SelectProductsAct
                    {
                        Number = r.SelectProductsAct.Number
                    },
                    AppDecisionId = r.AppDecisionId,
                    AppDecision = new AppDecision
                    {
                        Number = r.AppDecision.Number
                    },
                    ExpertDecisionId = r.AppDecisionId,
                    ExpertDecision = new ExpertDecision
                    {
                        Number = r.AppDecision.Number
                    },
                    Date = r.Date,
                    Number = r.Number
                })
                .ToListAsync();
        }

        public async Task<int> Create(Recommendation recommendation)
        {
            if (recommendation == null)
                return 0;

            appDBContext.Recommendations.Add(recommendation);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(Recommendation recommendation)
        {
            if (recommendation == null)
                return 0;

            appDBContext.Recommendations.Update(recommendation);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Recommendation? recommendation = await appDBContext.Recommendations.FindAsync(id);
            if (recommendation == null)
                return 0;

            appDBContext.Recommendations.Remove(recommendation);
            return await appDBContext.SaveChangesAsync();
        }
    }
}
