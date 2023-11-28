using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Documents
{
    public class GovStandardRepo : IRepository<GovStandard>
    {
        private readonly AppDBContext appDBContext;

        public GovStandardRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<GovStandard>> GetAll()
        {
            return await appDBContext.GovStandards.ToListAsync();
        }

        public async Task<GovStandard> Get(int id)
        {
            return await appDBContext.GovStandards.FirstOrDefaultAsync(a => a.Id == id) ?? new GovStandard();
        }

        public async Task<ICollection<GovStandard>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            var result = appDBContext.GovStandards.Where(c => c.Number.Contains(searchStr) 
                                                           || c.Name.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(GovStandard govStandard)
        {
            if (govStandard == null)
                return 0;

            appDBContext.GovStandards.Add(govStandard);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(GovStandard govStandard)
        {
            if (govStandard == null)
                return 0;

            appDBContext.GovStandards.Update(govStandard);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            GovStandard? govStandard = await appDBContext.GovStandards.FindAsync(id);
            if (govStandard == null)
                return 0;

            appDBContext.GovStandards.Remove(govStandard);
            return await appDBContext.SaveChangesAsync();
        }
    }
}
