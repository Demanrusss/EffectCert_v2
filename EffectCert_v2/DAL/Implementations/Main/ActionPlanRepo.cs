using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;
using EffectCert.DAL.Entities.Contractors;

namespace EffectCert.DAL.Implementations.Main
{
    public class ActionPlanRepo : IRepository<ActionPlan>
    {
        private readonly AppDBContext appDBContext;

        public ActionPlanRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<ActionPlan>> GetAll()
        {
            return await appDBContext.ActionPlans
                .Include(ap => ap.AppAnalizeExpert)
                    .ThenInclude(aae => aae.ContractorLegalEmployee)
                        .ThenInclude(cle => cle.ContractorIndividual)
                .Include(ap => ap.Application)
                .Include(ap => ap.ConformityAssessBodyHead)
                    .ThenInclude(cabh => cabh.ContractorLegalEmployee)
                        .ThenInclude(cle => cle.ContractorIndividual)
                .Include(ap => ap.RegDocumentEmployee)
                    .ThenInclude(rde => rde!.ContractorLegalEmployee)
                        .ThenInclude(cle => cle.ContractorIndividual)
                .Include(ap => ap.ResultsAnalizeExpert)
                    .ThenInclude(rae => rae!.ContractorLegalEmployee)
                        .ThenInclude(cle => cle.ContractorIndividual)
                .Include(ap => ap.SelectProductEmployee)
                    .ThenInclude(spe => spe!.ContractorIndividual)
                .Select(ap => new ActionPlan
                {
                    AppAnalizeExpertId = ap.AppAnalizeExpertId,
                    AppAnalizeExpert = new AssessBodyEmployee
                    {
                        ContractorLegalEmployee = new ContractorLegalEmployee
                        {
                            ContractorIndividual = new ContractorIndividual
                            {
                                LastName = ap.AppAnalizeExpert.ContractorLegalEmployee.ContractorIndividual.LastName,
                                FirstName = ap.AppAnalizeExpert.ContractorLegalEmployee.ContractorIndividual.FirstName
                            }
                        }
                    },
                    ApplicationId = ap.ApplicationId,
                    Application = new Application
                    {
                        Number = ap.Application.Number
                    },
                    ConformityAssessBodyHeadId = ap.ConformityAssessBodyHeadId,
                    ConformityAssessBodyHead = new AssessBodyEmployee
                    {
                        ContractorLegalEmployee = new ContractorLegalEmployee
                        {
                            ContractorIndividual = new ContractorIndividual
                            {
                                LastName = ap.ConformityAssessBodyHead.ContractorLegalEmployee.ContractorIndividual.LastName,
                                FirstName = ap.ConformityAssessBodyHead.ContractorLegalEmployee.ContractorIndividual.FirstName
                            }
                        }
                    },
                    SelectProductEmployeeId = ap.SelectProductEmployeeId,
                    SelectProductEmployee = new ContractorLegalEmployee
                    {
                        ContractorIndividual = new ContractorIndividual
                        {
                            LastName = ap.SelectProductEmployee!.ContractorIndividual.LastName,
                            FirstName = ap.SelectProductEmployee!.ContractorIndividual.FirstName
                        }
                    },
                    ResultsAnalizeExpertId = ap.ResultsAnalizeExpertId,
                    ResultsAnalizeExpert = new AssessBodyEmployee
                    {
                        ContractorLegalEmployee = new ContractorLegalEmployee
                        {
                            ContractorIndividual = new ContractorIndividual
                            {
                                LastName = ap.ResultsAnalizeExpert!.ContractorLegalEmployee.ContractorIndividual.LastName,
                                FirstName = ap.ResultsAnalizeExpert!.ContractorLegalEmployee.ContractorIndividual.FirstName
                            }
                        }
                    },
                    RegDocumentEmployeeId = ap.RegDocumentEmployeeId,
                    RegDocumentEmployee = new AssessBodyEmployee
                    {
                        ContractorLegalEmployee = new ContractorLegalEmployee
                        {
                            ContractorIndividual = new ContractorIndividual
                            {
                                LastName = ap.RegDocumentEmployee!.ContractorLegalEmployee.ContractorIndividual.LastName,
                                FirstName = ap.RegDocumentEmployee!.ContractorLegalEmployee.ContractorIndividual.FirstName
                            }
                        }
                    }
                })
                .ToListAsync();
        }

        public async Task<ActionPlan> Get(int id)
        {
            return await appDBContext.ActionPlans.FirstOrDefaultAsync(a => a.Id == id) ?? new ActionPlan();
        }

        public async Task<ICollection<ActionPlan>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.ActionPlans
                .Include(ap => ap.AppAnalizeExpert)
                    .ThenInclude(aae => aae.ContractorLegalEmployee)
                        .ThenInclude(cle => cle.ContractorIndividual)
                .Include(ap => ap.Application)
                .Include(ap => ap.ConformityAssessBodyHead)
                    .ThenInclude(cabh => cabh.ContractorLegalEmployee)
                        .ThenInclude(cle => cle.ContractorIndividual)
                .Include(ap => ap.RegDocumentEmployee)
                    .ThenInclude(rde => rde!.ContractorLegalEmployee)
                        .ThenInclude(cle => cle.ContractorIndividual)
                .Include(ap => ap.ResultsAnalizeExpert)
                    .ThenInclude(rae => rae!.ContractorLegalEmployee)
                        .ThenInclude(cle => cle.ContractorIndividual)
                .Include(ap => ap.SelectProductEmployee)
                    .ThenInclude(spe => spe!.ContractorIndividual)
                .Where(ap => ap.Number.Contains(searchStr))
                .Select(ap => new ActionPlan
                {
                    AppAnalizeExpertId = ap.AppAnalizeExpertId,
                    AppAnalizeExpert = new AssessBodyEmployee
                    {
                        ContractorLegalEmployee = new ContractorLegalEmployee
                        {
                            ContractorIndividual = new ContractorIndividual
                            {
                                LastName = ap.AppAnalizeExpert.ContractorLegalEmployee.ContractorIndividual.LastName,
                                FirstName = ap.AppAnalizeExpert.ContractorLegalEmployee.ContractorIndividual.FirstName
                            }
                        }
                    },
                    ApplicationId = ap.ApplicationId,
                    Application = new Application
                    {
                        Number = ap.Application.Number
                    },
                    ConformityAssessBodyHeadId = ap.ConformityAssessBodyHeadId,
                    ConformityAssessBodyHead = new AssessBodyEmployee
                    {
                        ContractorLegalEmployee = new ContractorLegalEmployee
                        {
                            ContractorIndividual = new ContractorIndividual
                            {
                                LastName = ap.ConformityAssessBodyHead.ContractorLegalEmployee.ContractorIndividual.LastName,
                                FirstName = ap.ConformityAssessBodyHead.ContractorLegalEmployee.ContractorIndividual.FirstName
                            }
                        }
                    },
                    SelectProductEmployeeId = ap.SelectProductEmployeeId,
                    SelectProductEmployee = new ContractorLegalEmployee
                    {
                        ContractorIndividual = new ContractorIndividual
                        {
                            LastName = ap.SelectProductEmployee!.ContractorIndividual.LastName,
                            FirstName = ap.SelectProductEmployee!.ContractorIndividual.FirstName
                        }
                    },
                    ResultsAnalizeExpertId = ap.ResultsAnalizeExpertId,
                    ResultsAnalizeExpert = new AssessBodyEmployee
                    {
                        ContractorLegalEmployee = new ContractorLegalEmployee
                        {
                            ContractorIndividual = new ContractorIndividual
                            {
                                LastName = ap.ResultsAnalizeExpert!.ContractorLegalEmployee.ContractorIndividual.LastName,
                                FirstName = ap.ResultsAnalizeExpert!.ContractorLegalEmployee.ContractorIndividual.FirstName
                            }
                        }
                    },
                    RegDocumentEmployeeId = ap.RegDocumentEmployeeId,
                    RegDocumentEmployee = new AssessBodyEmployee
                    {
                        ContractorLegalEmployee = new ContractorLegalEmployee
                        {
                            ContractorIndividual = new ContractorIndividual
                            {
                                LastName = ap.RegDocumentEmployee!.ContractorLegalEmployee.ContractorIndividual.LastName,
                                FirstName = ap.RegDocumentEmployee!.ContractorLegalEmployee.ContractorIndividual.FirstName
                            }
                        }
                    }
                })
                .ToListAsync();
        }

        public async Task<int> Create(ActionPlan actionPlan)
        {
            if (actionPlan == null)
                return 0;

            appDBContext.ActionPlans.Add(actionPlan);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(ActionPlan actionPlan)
        {
            if (actionPlan == null)
                return 0;

            appDBContext.ActionPlans.Update(actionPlan);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            ActionPlan? actionPlan = await appDBContext.ActionPlans.FindAsync(id);
            if (actionPlan == null)
                return 0;

            appDBContext.ActionPlans.Remove(actionPlan);
            return await appDBContext.SaveChangesAsync();
        }
    }
}
