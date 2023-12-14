using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;
using EffectCert.DAL.Entities.Documents;

namespace EffectCert.DAL.Implementations.Contractors
{
    public class AssessBodyRepo : IRepository<AssessBody>
    {
        private readonly AppDBContext appDBContext;

        public AssessBodyRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<AssessBody>> GetAll()
        {
            return await appDBContext.AssessBodies
                .Include(ab => ab.Address)
                .Include(ab => ab.Attestate)
                .Include(ab => ab.ContractorLegal)
                .Select(ab => new AssessBody
                {
                    Id = ab.Id,
                    Name = ab.Name,
                    ShortName = ab.ShortName,
                    AddressId = ab.AddressId,
                    AttestateId = ab.AttestateId,
                    ContractorLegalId = ab.ContractorLegalId,
                    Address = new Address
                    {
                        AddressStr = ab.Address.AddressStr,
                        Country = ab.Address.Country
                    },
                    Attestate = new Attestate
                    {
                        Number = ab.Attestate.Number
                    },
                    ContractorLegal = new ContractorLegal
                    {
                        ShortName = ab.ContractorLegal.ShortName
                    }
                })
                .ToListAsync();
        }

        public async Task<AssessBody> Get(int id)
        {
            return await appDBContext.AssessBodies
                .Include(ab => ab.Address)
                .Include(ab => ab.Attestate)
                .Include(ab => ab.ContractorLegal)
                .Include(ab => ab.Employees)
                    .ThenInclude(e => e.ContractorLegalEmployee)
                        .ThenInclude(cle => cle.ContractorIndividual)
                .FirstOrDefaultAsync(a => a.Id == id) ?? new AssessBody();
        }

        public async Task<ICollection<AssessBody>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.AssessBodies
                .Include(ab => ab.Address)
                .Include(ab => ab.Attestate)
                .Include(ab => ab.ContractorLegal)
                .Where(ab => ab.Name.Contains(searchStr) || ab.ShortName.Contains(searchStr))
                .Select(ab => new AssessBody
                {
                    Id = ab.Id,
                    Name = ab.Name,
                    ShortName = ab.ShortName,
                    AddressId = ab.AddressId,
                    AttestateId = ab.AttestateId,
                    ContractorLegalId = ab.ContractorLegalId,
                    Address = new Address
                    {
                        AddressStr = ab.Address.AddressStr,
                        Country = ab.Address.Country
                    },
                    Attestate = new Attestate
                    {
                        Number = ab.Attestate.Number
                    },
                    ContractorLegal = new ContractorLegal
                    {
                        ShortName = ab.ContractorLegal.ShortName
                    }
                })
                .ToListAsync();
        }

        public async Task<int> Create(AssessBody assessBody)
        {
            if (assessBody == null)
                return 0;

            appDBContext.AssessBodies.Add(assessBody);
            await appDBContext.SaveChangesAsync();

            UpdateEmployees(assessBody);

            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(AssessBody assessBody)
        {
            if (assessBody == null)
                return 0;

            appDBContext.AssessBodies.Update(assessBody);
            UpdateEmployees(assessBody);

            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            AssessBody? assessBody = await appDBContext.AssessBodies.FindAsync(id);
            if (assessBody == null)
                return 0;

            appDBContext.AssessBodies.Remove(assessBody);
            return await appDBContext.SaveChangesAsync();
        }

        private void UpdateEmployees(AssessBody assessBody)
        {
            List<int> ids = new List<int>(assessBody.Employees.Count);
            foreach (var employee in assessBody.Employees)
            {
                ids.Add(employee.Id);

                appDBContext.Attach(employee);
                appDBContext.Entry(employee).Property(abe => abe.AssessBodyId).IsModified = true;
            }

            var dbEmployees = appDBContext.AssessBodyEmployees
                .Include(abe => abe.ContractorLegalEmployee)
                .Where(abe => abe.AssessBodyId == assessBody.Id
                              && !ids.Contains(abe.Id))
                .Select(abe => new AssessBodyEmployee
                {
                    Id = abe.Id,
                    AssessBodyId = abe.AssessBodyId
                });

            foreach (var dbEmployee in dbEmployees)
            {
                dbEmployee.AssessBodyId = assessBody.Employees.Any(e => e.Id == dbEmployee.Id)
                    ? assessBody.Id
                    : null;

                appDBContext.Attach(dbEmployee);
                appDBContext.Entry(dbEmployee).Property(abe => abe.AssessBodyId).IsModified = true;
            }
        }
    }
}
