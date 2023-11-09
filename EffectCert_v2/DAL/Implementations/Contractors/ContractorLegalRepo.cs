using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

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
                .FirstOrDefaultAsync(a => a.Id == id) ?? new ContractorLegal();
        }

        public async Task<ICollection<ContractorLegal>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            var result = appDBContext.ContractorLegals
                .Where(c => c.ShortName.Contains(searchStr) || c.FullName.Contains(searchStr));

            return await result.ToListAsync();
        }

        public async Task<int> Create(ContractorLegal contractorLegal)
        {
            if (contractorLegal == null)
                return 0;

            appDBContext.ContractorLegals.Add(contractorLegal);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(ContractorLegal contractorLegal)
        {
            if (contractorLegal == null)
                return 0;

            appDBContext.ContractorLegals.Update(contractorLegal);
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
