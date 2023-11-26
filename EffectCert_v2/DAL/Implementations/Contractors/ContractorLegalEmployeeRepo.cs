using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Contractors
{
    public class ContractorLegalEmployeeRepo : IRepository<ContractorLegalEmployee>
    {
        private readonly AppDBContext appDBContext;

        public ContractorLegalEmployeeRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<ContractorLegalEmployee>> GetAll()
        {
            return await appDBContext.ContractorLegalEmployees
                .Include(cle => cle.ContractorIndividual)
                .Select(cle => new ContractorLegalEmployee
                {
                    Id = cle.Id,
                    ContractorIndividualId = cle.ContractorIndividualId,
                    ContractorIndividual = new ContractorIndividual
                    {
                        FirstName = cle.ContractorIndividual.FirstName,
                        LastName = cle.ContractorIndividual.LastName
                    },
                    IsManager = cle.IsManager,
                    Position = cle.Position
                })
                .ToListAsync();
        }

        public async Task<ContractorLegalEmployee> Get(int id)
        {
            return await appDBContext.ContractorLegalEmployees.FirstOrDefaultAsync(a => a.Id == id) ?? new ContractorLegalEmployee();
        }

        public async Task<ICollection<ContractorLegalEmployee>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            var result = from cle in appDBContext.ContractorLegalEmployees
                         join ci in appDBContext.ContractorIndividuals on cle.ContractorIndividual.Id equals ci.Id
                         where ci.FirstName.Contains(searchStr) || ci.LastName.Contains(searchStr)
                         select cle;
            return await result.ToListAsync();
        }

        public async Task<ICollection<ContractorLegalEmployee>> FindByPosition(string searchStr = "")
        {
            var result = appDBContext.ContractorLegalEmployees.Where(c => c.Position.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(ContractorLegalEmployee contractorLegalEmployee)
        {
            if (contractorLegalEmployee == null)
                throw new ArgumentNullException();

            appDBContext.ContractorLegalEmployees.Add(contractorLegalEmployee);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(ContractorLegalEmployee contractorLegalEmployee)
        {
            if (contractorLegalEmployee == null)
                return 0;

            appDBContext.ContractorLegalEmployees.Update(contractorLegalEmployee);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            ContractorLegalEmployee? contractorLegalEmployee = await appDBContext.ContractorLegalEmployees.FindAsync(id);
            if (contractorLegalEmployee == null)
                return 0;

            appDBContext.ContractorLegalEmployees.Remove(contractorLegalEmployee);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
