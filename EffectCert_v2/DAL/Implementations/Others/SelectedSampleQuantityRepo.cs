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
            return await appDBContext.SelectedSampleQuantities
                .Include(ssq => ssq.MeasurementUnit)
                .Include(ssq => ssq.ProductQuantity)
                .Select(ssq => new SelectedSampleQuantity
                {
                    Id = ssq.Id,
                    MeasurementUnitId = ssq.MeasurementUnitId,
                    MeasurementUnit = new MeasurementUnit
                    {
                        ShortName = ssq.MeasurementUnit.ShortName
                    },
                    ProductQuantityId = ssq.ProductQuantityId,
                    ProductQuantity = new ProductQuantity
                    {
                        Quantity = ssq.ProductQuantity.Quantity
                    },
                    Quantity = ssq.Quantity
                })
                .ToListAsync();
        }

        public async Task<SelectedSampleQuantity> Get(int id)
        {
            return await appDBContext.SelectedSampleQuantities.FirstOrDefaultAsync(a => a.Id == id) ?? new SelectedSampleQuantity();
        }

        public async Task<ICollection<SelectedSampleQuantity>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            var item2 = appDBContext.SelectedSampleQuantities.First().ProductQuantity.Id;

            var result = from ssq in appDBContext.SelectedSampleQuantities
                         join p in appDBContext.ProductQuantities on ssq.ProductQuantity.Id equals p.Id
                         where p.Product.Name.Contains(searchStr)
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
