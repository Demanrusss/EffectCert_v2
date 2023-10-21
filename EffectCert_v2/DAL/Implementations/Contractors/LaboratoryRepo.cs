using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Contractors
{
    public class LaboratoryRepo : IRepository<Laboratory>
    {
        private readonly AppDBContext appDBContext;

        public LaboratoryRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<Laboratory>> GetAll()
        {
            return await appDBContext.Laboratories.ToListAsync();
        }

        public async Task<Laboratory> Get(int id)
        {
            return await appDBContext.Laboratories.FirstOrDefaultAsync(a => a.Id == id) ?? new Laboratory();
        }

        public async Task<ICollection<Laboratory>> Find(string searchStr = "")
        {
            var result = appDBContext.Laboratories.Where(c => c.Name.Contains(searchStr) || c.ShortName.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(Laboratory laboratory)
        {
            if (laboratory == null)
                throw new ArgumentNullException();

            appDBContext.Laboratories.Add(laboratory);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(Laboratory laboratory)
        {
            if (laboratory == null)
                return 0;

            appDBContext.Laboratories.Update(laboratory);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Laboratory? laboratory = await appDBContext.Laboratories.FindAsync(id);
            if (laboratory == null)
                return 0;

            appDBContext.Laboratories.Remove(laboratory);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
