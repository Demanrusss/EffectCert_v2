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
            return await appDBContext.ContractorLegalEmployees
                .Include(cle => cle.ContractorIndividual)
                .FirstOrDefaultAsync(a => a.Id == id) ?? new ContractorLegalEmployee();
        }

        public async Task<ICollection<ContractorLegalEmployee>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.ContractorLegalEmployees
                .Include(cle => cle.ContractorIndividual)
                .Where(cle => cle.ContractorIndividual.FirstName.Contains(searchStr) 
                              || cle.ContractorIndividual.LastName.Contains(searchStr))
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

        public async Task<ICollection<ContractorLegalEmployee>> FindByPosition(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.ContractorLegalEmployees
                .Include(cle => cle.ContractorIndividual)
                .Where(cle => cle.Position.Contains(searchStr))
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

        public async Task<int> Create(ContractorLegalEmployee contractorLegalEmployee)
        {
            if (contractorLegalEmployee == null)
                return 0;

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
