using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;

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
            return await appDBContext.ExpertDecisions
                .Include(ed => ed.Application)
                .Include(ed => ed.Expert)
                    .ThenInclude(e => e.ContractorLegalEmployee)
                        .ThenInclude(cle => cle.ContractorIndividual)
                .Include(ed => ed.TestProtocols)
                .Select(ed => new ExpertDecision
                {
                    Id = ed.Id,
                    ApplicationId = ed.ApplicationId,
                    Application = new Application
                    {
                        Number = ed.Application.Number
                    },
                    ExpertId = ed.ExpertId,
                    Expert = new AssessBodyEmployee
                    {
                        ContractorLegalEmployee = new ContractorLegalEmployee
                        {
                            ContractorIndividual = new ContractorIndividual
                            {
                                LastName = ed.Expert.ContractorLegalEmployee.ContractorIndividual.LastName,
                                FirstName = ed.Expert.ContractorLegalEmployee.ContractorIndividual.FirstName
                            }
                        }
                    },
                    TestProtocols = ed.TestProtocols.Select(tp => new TestProtocol
                    {
                        Number = tp.Number,
                        Date = tp.Date,
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<ExpertDecision> Get(int id)
        {
            return await appDBContext.ExpertDecisions.FirstOrDefaultAsync(a => a.Id == id) ?? new ExpertDecision();
        }

        public async Task<ICollection<ExpertDecision>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.ExpertDecisions
                .Include(ed => ed.Application)
                .Include(ed => ed.Expert)
                    .ThenInclude(e => e.ContractorLegalEmployee)
                        .ThenInclude(cle => cle.ContractorIndividual)
                .Include(ed => ed.TestProtocols)
                .Where(ed => ed.Number.Contains(searchStr))
                .Select(ed => new ExpertDecision
                {
                    Id = ed.Id,
                    ApplicationId = ed.ApplicationId,
                    Application = new Application
                    {
                        Number = ed.Application.Number
                    },
                    ExpertId = ed.ExpertId,
                    Expert = new AssessBodyEmployee
                    {
                        ContractorLegalEmployee = new ContractorLegalEmployee
                        {
                            ContractorIndividual = new ContractorIndividual
                            {
                                LastName = ed.Expert.ContractorLegalEmployee.ContractorIndividual.LastName,
                                FirstName = ed.Expert.ContractorLegalEmployee.ContractorIndividual.FirstName
                            }
                        }
                    },
                    TestProtocols = ed.TestProtocols.Select(tp => new TestProtocol
                    {
                        Number = tp.Number,
                        Date = tp.Date,
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<int> Create(ExpertDecision expertDecision)
        {
            if (expertDecision == null)
                return 0;

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
