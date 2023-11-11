using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Documents
{
    public class GTDRepo : IRepository<GTD>
    {
        private readonly AppDBContext appDBContext;

        public GTDRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<GTD>> GetAll()
        {
            return await appDBContext.GTDs.ToListAsync();
        }

        public async Task<GTD> Get(int id)
        {
            return await appDBContext.GTDs.FirstOrDefaultAsync(a => a.Id == id) ?? new GTD();
        }

        public async Task<ICollection<GTD>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            var result = appDBContext.GTDs.Where(c => c.Number.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(GTD gTD)
        {
            if (gTD == null)
                throw new ArgumentNullException();

            appDBContext.GTDs.Add(gTD);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(GTD gTD)
        {
            if (gTD == null)
                return 0;

            appDBContext.GTDs.Update(gTD);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            GTD? gTD = await appDBContext.GTDs.FindAsync(id);
            if (gTD == null)
                return 0;

            appDBContext.GTDs.Remove(gTD);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
