using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Contractors
{
    public class AssessBodyEmployeeRepo : IRepository<AssessBodyEmployee>
    {
        private readonly AppDBContext appDBContext;

        public AssessBodyEmployeeRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<AssessBodyEmployee>> GetAll()
        {
            return await appDBContext.AssessBodyEmployees
                .Include(abe => abe.ContractorLegalEmployee)
                    .ThenInclude(cle => cle.ContractorIndividual)
                .Select(abe => new AssessBodyEmployee
                {
                    Id = abe.Id,
                    ContractorLegalEmployeeId = abe.ContractorLegalEmployeeId,
                    ContractorLegalEmployee = new ContractorLegalEmployee
                    { 
                        ContractorIndividual = new ContractorIndividual
                        {
                            FirstName = abe.ContractorLegalEmployee.ContractorIndividual.FirstName,
                            LastName = abe.ContractorLegalEmployee.ContractorIndividual.LastName
                        }
                    },
                    ExpertAuditorOrientation = abe.ExpertAuditorOrientation,
                    Position = abe.Position
                })
                .ToListAsync();
        }

        public async Task<AssessBodyEmployee> Get(int id)
        {
            return await appDBContext.AssessBodyEmployees.FirstOrDefaultAsync(a => a.Id == id) ?? new AssessBodyEmployee();
        }

        public async Task<ICollection<AssessBodyEmployee>> Find(string searchStr = "")
        {
            var result = from abe in appDBContext.AssessBodyEmployees
                         join cle in appDBContext.ContractorLegalEmployees on abe.ContractorLegalEmployee.Id equals cle.Id
                         join ci in appDBContext.ContractorIndividuals on cle.ContractorIndividual.Id equals ci.Id
                         where ci.FirstName.Contains(searchStr) || ci.LastName.Contains(searchStr)
                         select abe;
            return await result.ToListAsync();
        }

        public async Task<IEnumerable<AssessBodyEmployee>> FindByPosition(string searchStr = "")
        {
            var result = appDBContext.AssessBodyEmployees.Where(c => c.Position.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(AssessBodyEmployee assessBodyEmployee)
        {
            if (assessBodyEmployee == null)
                throw new ArgumentNullException();

            appDBContext.AssessBodyEmployees.Add(assessBodyEmployee);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(AssessBodyEmployee assessBodyEmployee)
        {
            if (assessBodyEmployee == null)
                return 0;

            appDBContext.AssessBodyEmployees.Update(assessBodyEmployee);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            AssessBodyEmployee? assessBodyEmployee = await appDBContext.AssessBodyEmployees.FindAsync(id);
            if (assessBodyEmployee == null)
                return 0;

            appDBContext.AssessBodyEmployees.Remove(assessBodyEmployee);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
