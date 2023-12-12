using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;
using System.Linq.Expressions;
using System.Linq;

namespace EffectCert.DAL.Implementations.Contractors
{
    public class ContractorLegalRepo : IRepository<ContractorLegal>
    {
        private readonly AppDBContext appDBContext;

        public ContractorLegalRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<ContractorLegal>> GetAll()
        {
            return await appDBContext.ContractorLegals
                .Include(cl => cl.RegAddress)
                .Select(c => new ContractorLegal
                {
                    BIN = c.BIN,
                    Id = c.Id,
                    ShortName = c.ShortName,
                    RegAddress = new Address
                    {
                        AddressStr = c.RegAddress.AddressStr,
                        Country = c.RegAddress.Country
                    },
                    RegAddressId = c.RegAddressId
                })
                .ToListAsync();
        }

        public async Task<ContractorLegal> Get(int id)
        {
            return await appDBContext.ContractorLegals
                .Include(cl => cl.FactAddress)
                .Include(cl => cl.RegAddress)
                .Include(cl => cl.BankAccount)
                .Include(cl => cl.Employees)
                    .ThenInclude(cle => cle.ContractorIndividual)
                .FirstOrDefaultAsync(a => a.Id == id) ?? new ContractorLegal();
        }

        public async Task<ICollection<ContractorLegal>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.ContractorLegals
                .Include(cl => cl.RegAddress)
                .Where(cl => cl.ShortName.Contains(searchStr) || cl.Name.Contains(searchStr))
                .Select(c => new ContractorLegal
                {
                    BIN = c.BIN,
                    Id = c.Id,
                    ShortName = c.ShortName,
                    RegAddress = new Address
                    {
                        AddressStr = c.RegAddress.AddressStr,
                        Country = c.RegAddress.Country
                    },
                    RegAddressId = c.RegAddressId
                })
                .ToListAsync();
        }

        public async Task<int> Create(ContractorLegal contractorLegal)
        {
            if (contractorLegal == null)
                return 0;

            appDBContext.ContractorLegals.Add(contractorLegal);
            await appDBContext.SaveChangesAsync();

            var dbEmployees = appDBContext.ContractorLegalEmployees
                .Where(cle => cle.ContractorLegalId == contractorLegal.Id
                              || contractorLegal.Employees.Any(e => e.Id == cle.Id))
                .Select(cle => new ContractorLegalEmployee
                {
                    Id = cle.Id,
                    ContractorLegalId = cle.ContractorLegalId
                });

            foreach (var dbEmployee in dbEmployees)
            {
                dbEmployee.ContractorLegalId = contractorLegal.Employees.Any(e => e.Id == dbEmployee.Id) 
                    ? contractorLegal.Id
                    : null;

                appDBContext.Attach(dbEmployee);
                appDBContext.Entry(dbEmployee).Property(cle => cle.ContractorLegalId).IsModified = true;
            }

            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(ContractorLegal contractorLegal)
        {
            if (contractorLegal == null)
                return 0;

            appDBContext.ContractorLegals.Update(contractorLegal);

            List<int> ids = new List<int>(contractorLegal.Employees.Count);
            foreach (var employee in contractorLegal.Employees)
            {
                ids.Add(employee.Id);

                appDBContext.Attach(employee);
                appDBContext.Entry(employee).Property(cle => cle.ContractorLegalId).IsModified = true;
            }

            var dbEmployees = appDBContext.ContractorLegalEmployees
                .Where(cle => cle.ContractorLegalId == contractorLegal.Id
                              && !ids.Contains(cle.Id))
                .Select(cle => new ContractorLegalEmployee
                {
                    Id = cle.Id,
                    ContractorLegalId = cle.ContractorLegalId
                });

            foreach (var dbEmployee in dbEmployees)
            {
                dbEmployee.ContractorLegalId = null;

                appDBContext.Attach(dbEmployee);
                appDBContext.Entry(dbEmployee).Property(cle => cle.ContractorLegalId).IsModified = true;
            }

            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            ContractorLegal? contractorLegal = await appDBContext.ContractorLegals.FindAsync(id);
            if (contractorLegal == null)
                return 0;

            appDBContext.ContractorLegals.Remove(contractorLegal);
            return await appDBContext.SaveChangesAsync();
        }
    }
}
