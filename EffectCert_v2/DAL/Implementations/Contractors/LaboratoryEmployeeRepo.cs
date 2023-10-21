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
            return await appDBContext.LaboratoryEmployees.ToListAsync();
        }

        public async Task<LaboratoryEmployee> Get(int id)
        {
            return await appDBContext.LaboratoryEmployees.FirstOrDefaultAsync(a => a.Id == id) ?? new LaboratoryEmployee();
        }

        public async Task<ICollection<LaboratoryEmployee>> Find(string searchStr = "")
        {
            var result = from le in appDBContext.LaboratoryEmployees
                         join cle in appDBContext.ContractorLegalEmployees on le.ContractorLegalEmployee.Id equals cle.Id
                         join ci in appDBContext.ContractorIndividuals on cle.ContractorIndividual.Id equals ci.Id
                         where ci.FirstName.Contains(searchStr) || ci.LastName.Contains(searchStr)
                         select le;
            return await result.ToListAsync();
        }

        public async Task<ICollection<LaboratoryEmployee>> FindByPosition(string searchStr = "")
        {
            var result = appDBContext.LaboratoryEmployees.Where(c => c.Position.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(LaboratoryEmployee laboratoryEmployee)
        {
            if (laboratoryEmployee == null)
                throw new ArgumentNullException();

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
