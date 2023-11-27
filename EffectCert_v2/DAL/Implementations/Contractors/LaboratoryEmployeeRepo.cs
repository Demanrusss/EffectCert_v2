using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Contractors
{
    public class LaboratoryEmployeeRepo : IRepository<LaboratoryEmployee>
    {
        private readonly AppDBContext appDBContext;

        public LaboratoryEmployeeRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<LaboratoryEmployee>> GetAll()
        {
            return await appDBContext.LaboratoryEmployees
                .Include(le => le.ContractorLegalEmployee)
                    .ThenInclude(cle => cle.ContractorIndividual)
                .Select(le => new LaboratoryEmployee
                {
                    Id = le.Id,
                    ContractorLegalEmployeeId = le.ContractorLegalEmployeeId,
                    ContractorLegalEmployee = new ContractorLegalEmployee
                    {
                        ContractorIndividual = new ContractorIndividual
                        {
                            LastName = le.ContractorLegalEmployee.ContractorIndividual.LastName,
                            FirstName = le.ContractorLegalEmployee.ContractorIndividual.FirstName
                        }
                    },
                    Position = le.Position
                })
                .ToListAsync();
        }

        public async Task<LaboratoryEmployee> Get(int id)
        {
            return await appDBContext.LaboratoryEmployees
                .Include(le => le.ContractorLegalEmployee)
                    .ThenInclude(cle => cle.ContractorIndividual)
                .FirstOrDefaultAsync(a => a.Id == id) ?? new LaboratoryEmployee();
        }

        public async Task<ICollection<LaboratoryEmployee>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.LaboratoryEmployees
                .Include(le => le.ContractorLegalEmployee)
                    .ThenInclude(cle => cle.ContractorIndividual)
                .Where(le => le.ContractorLegalEmployee.ContractorIndividual.FirstName.Contains(searchStr) 
                             || le.ContractorLegalEmployee.ContractorIndividual.LastName.Contains(searchStr))
                .Select(le => new LaboratoryEmployee
                {
                    Id = le.Id,
                    ContractorLegalEmployeeId = le.ContractorLegalEmployeeId,
                    ContractorLegalEmployee = new ContractorLegalEmployee
                    {
                        ContractorIndividual = new ContractorIndividual
                        {
                            LastName = le.ContractorLegalEmployee.ContractorIndividual.LastName,
                            FirstName = le.ContractorLegalEmployee.ContractorIndividual.FirstName
                        }
                    },
                    Position = le.Position
                })
                .ToListAsync();
        }

        public async Task<ICollection<LaboratoryEmployee>> FindByPosition(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.LaboratoryEmployees
                .Include(le => le.ContractorLegalEmployee)
                    .ThenInclude(cle => cle.ContractorIndividual)
                .Where(c => c.Position.Contains(searchStr))
                .ToListAsync();
        }

        public async Task<int> Create(LaboratoryEmployee laboratoryEmployee)
        {
            if (laboratoryEmployee == null)
                return 0;

            appDBContext.LaboratoryEmployees.Add(laboratoryEmployee);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(LaboratoryEmployee laboratoryEmployee)
        {
            if (laboratoryEmployee == null)
                return 0;

            appDBContext.LaboratoryEmployees.Update(laboratoryEmployee);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            LaboratoryEmployee? laboratoryEmployee = await appDBContext.LaboratoryEmployees.FindAsync(id);
            if (laboratoryEmployee == null)
                return 0;

            appDBContext.LaboratoryEmployees.Remove(laboratoryEmployee);
            return await appDBContext.SaveChangesAsync();
        }
    }
}
