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
            return await appDBContext.ContractorLegals.ToListAsync();
        }

        public async Task<ContractorLegal> Get(int id)
        {
            return await appDBContext.ContractorLegals.FirstOrDefaultAsync(a => a.Id == id) ?? new ContractorLegal();
        }

        public async Task<ICollection<ContractorLegal>> Find(string searchStr = "")
        {
            var result = appDBContext.ContractorLegals.Where(c => c.ShortName.Contains(searchStr) || c.FullName.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(ContractorLegal contractorLegal)
        {
            if (contractorLegal == null)
                throw new ArgumentNullException();

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
