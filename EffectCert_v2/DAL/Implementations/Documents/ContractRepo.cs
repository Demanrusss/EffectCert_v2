using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Documents
{
    public class ContractRepo : IRepository<Contract>
    {
        private readonly AppDBContext appDBContext;

        public ContractRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<Contract>> GetAll()
        {
            return await appDBContext.Contracts.ToListAsync();
        }

        public async Task<Contract> Get(int id)
        {
            return await appDBContext.Contracts.FirstOrDefaultAsync(a => a.Id == id) ?? new Contract();
        }

        public async Task<ICollection<Contract>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            var result = appDBContext.Contracts.Where(c => c.Number.Contains(searchStr) 
                                                           || c.Name.Contains(searchStr) 
                                                           || c.ShortName.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(Contract contract)
        {
            if (contract == null)
                throw new ArgumentNullException();

            appDBContext.Contracts.Add(contract);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(Contract contract)
        {
            if (contract == null)
                return 0;

            appDBContext.Contracts.Update(contract);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Contract? contract = await appDBContext.Contracts.FindAsync(id);
            if (contract == null)
                return 0;

            appDBContext.Contracts.Remove(contract);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
