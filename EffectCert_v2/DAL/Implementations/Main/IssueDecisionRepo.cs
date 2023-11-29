using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;
using EffectCert.DAL.Entities.Documents;

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
            return await appDBContext.IssueDecisions
                .Include(id => id.Application)
                .Include(id => id.Certificate)
                .Include(id => id.Declaration)
                .Include(id => id.ExpertDecision)
                .Include(id => id.Recommendation)
                .Select(id => new IssueDecision
                {
                    Id = id.Id,
                    ApplicationId = id.ApplicationId,
                    Application = new Application
                    {
                        Number = id.Application.Number,
                        Date = id.Application.Date
                    },
                    CertificateId = id.CertificateId,
                    Certificate = new Certificate
                    {
                        Number = id.Certificate!.Number,
                        Date = id.Certificate!.Date
                    },
                    DeclarationId = id.DeclarationId,
                    Declaration = new Declaration
                    {
                        Number = id.Declaration!.Number,
                        Date = id.Declaration!.Date
                    },
                    ExpertDecisionId = id.ExpertDecisionId,
                    ExpertDecision = new ExpertDecision
                    {
                        Number = id.ExpertDecision.Number,
                        Date = id.ExpertDecision.Date
                    },
                    RecommendationId = id.RecommendationId,
                    Recommendation = new Recommendation
                    {
                        Number = id.Recommendation.Number,
                        Date = id.Recommendation.Date
                    }
                })
                .ToListAsync();
        }

        public async Task<IssueDecision> Get(int id)
        {
            return await appDBContext.IssueDecisions.FirstOrDefaultAsync(a => a.Id == id) ?? new IssueDecision();
        }

        public async Task<ICollection<IssueDecision>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.IssueDecisions
                .Include(id => id.Application)
                .Include(id => id.Certificate)
                .Include(id => id.Declaration)
                .Include(id => id.ExpertDecision)
                .Include(id => id.Recommendation)
                .Where(id => id.Number.Contains(searchStr))
                .Select(id => new IssueDecision
                {
                    Id = id.Id,
                    ApplicationId = id.ApplicationId,
                    Application = new Application
                    {
                        Number = id.Application.Number,
                        Date = id.Application.Date
                    },
                    CertificateId = id.CertificateId,
                    Certificate = new Certificate
                    {
                        Number = id.Certificate!.Number,
                        Date = id.Certificate!.Date
                    },
                    DeclarationId = id.DeclarationId,
                    Declaration = new Declaration
                    {
                        Number = id.Declaration!.Number,
                        Date = id.Declaration!.Date
                    },
                    ExpertDecisionId = id.ExpertDecisionId,
                    ExpertDecision = new ExpertDecision
                    {
                        Number = id.ExpertDecision.Number,
                        Date = id.ExpertDecision.Date
                    },
                    RecommendationId = id.RecommendationId,
                    Recommendation = new Recommendation
                    {
                        Number = id.Recommendation.Number,
                        Date = id.Recommendation.Date
                    }
                })
                .ToListAsync();
        }

        public async Task<int> Create(IssueDecision issueDecision)
        {
            if (issueDecision == null)
                return 0;

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
