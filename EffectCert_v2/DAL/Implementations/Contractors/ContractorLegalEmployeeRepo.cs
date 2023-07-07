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

        public async Task<IEnumerable<ContractorLegalEmployee>> GetAll()
        {
            return await appDBContext.ContractorLegalEmployees.ToListAsync();
        }

        public async Task<ContractorLegalEmployee> Get(int id)
        {
            return await appDBContext.ContractorLegalEmployees.FirstOrDefaultAsync(a => a.Id == id) ?? new ContractorLegalEmployee();
        }

        public async Task<IEnumerable<ContractorLegalEmployee>> Find(string searchStr = "")
        {
            var result = from cle in appDBContext.ContractorLegalEmployees
                         join ci in appDBContext.ContractorIndividuals on cle.ContractorIndividualId equals ci.Id
                         where ci.FirstName.Contains(searchStr) || ci.LastName.Contains(searchStr)
                         select cle;
            return await result.ToListAsync();
        }

        public async Task<IEnumerable<ContractorLegalEmployee>> FindByPosition(string searchStr = "")
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
