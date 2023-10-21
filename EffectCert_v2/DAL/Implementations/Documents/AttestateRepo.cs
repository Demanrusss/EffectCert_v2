using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Documents
{
    public class AttestateRepo : IRepository<Attestate>
    {
        private readonly AppDBContext appDBContext;

        public AttestateRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<Attestate>> GetAll()
        {
            return await appDBContext.Attestates.ToListAsync();
        }

        public async Task<Attestate> Get(int id)
        {
            return await appDBContext.Attestates.FirstOrDefaultAsync(a => a.Id == id) ?? new Attestate();
        }

        public async Task<ICollection<Attestate>> Find(string searchStr = "")
        {
            var result = appDBContext.Attestates.Where(c => c.Number.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(Attestate attestate)
        {
            if (attestate == null)
                throw new ArgumentNullException();

            appDBContext.Attestates.Add(attestate);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(Attestate attestate)
        {
            if (attestate == null)
                return 0;

            appDBContext.Attestates.Update(attestate);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Attestate? attestate = await appDBContext.Attestates.FindAsync(id);
            if (attestate == null)
                return 0;

            appDBContext.Attestates.Remove(attestate);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
