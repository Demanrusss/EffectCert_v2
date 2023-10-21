using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Others
{
    public class SelectedSampleQuantityRepo : IRepository<SelectedSampleQuantity>
    {
        private readonly AppDBContext appDBContext;

        public SelectedSampleQuantityRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<SelectedSampleQuantity>> GetAll()
        {
            return await appDBContext.SelectedSampleQuantities.ToListAsync();
        }

        public async Task<SelectedSampleQuantity> Get(int id)
        {
            return await appDBContext.SelectedSampleQuantities.FirstOrDefaultAsync(a => a.Id == id) ?? new SelectedSampleQuantity();
        }

        public async Task<ICollection<SelectedSampleQuantity>> Find(string searchStr = "")
        {
            var item2 = appDBContext.SelectedSampleQuantities.First().Product.Id;

            var result = from ssq in appDBContext.SelectedSampleQuantities
                         join p in appDBContext.Products on ssq.Product.Id equals p.Id
                         where p.Name.Contains(searchStr)
                         select ssq;
            return await result.ToListAsync();
        }

        public async Task<int> Create(SelectedSampleQuantity selectedSampleQuantity)
        {
            if (selectedSampleQuantity == null)
                throw new ArgumentNullException();

            appDBContext.SelectedSampleQuantities.Add(selectedSampleQuantity);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(SelectedSampleQuantity selectedSampleQuantity)
        {
            if (selectedSampleQuantity == null)
                return 0;

            appDBContext.SelectedSampleQuantities.Update(selectedSampleQuantity);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            SelectedSampleQuantity? selectedSampleQuantity = await appDBContext.SelectedSampleQuantities.FindAsync(id);
            if (selectedSampleQuantity == null)
                return 0;

            appDBContext.SelectedSampleQuantities.Remove(selectedSampleQuantity);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
