using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Documents
{
    public class ManufacturerStandardRepo : IRepository<ManufacturerStandard>
    {
        private readonly AppDBContext appDBContext;

        public ManufacturerStandardRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<IEnumerable<ManufacturerStandard>> GetAll()
        {
            return await appDBContext.ManufacturerStandards.ToListAsync();
        }

        public async Task<ManufacturerStandard> Get(int id)
        {
            return await appDBContext.ManufacturerStandards.FirstOrDefaultAsync(a => a.Id == id) ?? new ManufacturerStandard();
        }

        public async Task<IEnumerable<ManufacturerStandard>> Find(string searchStr = "")
        {
            var result = appDBContext.ManufacturerStandards.Where(c => c.Number.Contains(searchStr)
                                                                       || c.Name.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(ManufacturerStandard manufacturerStandard)
        {
            if (manufacturerStandard == null)
                throw new ArgumentNullException();

            appDBContext.ManufacturerStandards.Add(manufacturerStandard);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(ManufacturerStandard manufacturerStandard)
        {
            if (manufacturerStandard == null)
                return 0;

            appDBContext.ManufacturerStandards.Update(manufacturerStandard);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            ManufacturerStandard? manufacturerStandard = await appDBContext.ManufacturerStandards.FindAsync(id);
            if (manufacturerStandard == null)
                return 0;

            appDBContext.ManufacturerStandards.Remove(manufacturerStandard);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
