using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Others
{
    public class ProductQuantityRepo : IRepository<ProductQuantity>
    {
        private readonly AppDBContext appDBContext;

        public ProductQuantityRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<IEnumerable<ProductQuantity>> GetAll()
        {
            return await appDBContext.ProductQuantities.ToListAsync();
        }

        public async Task<ProductQuantity> Get(int id)
        {
            return await appDBContext.ProductQuantities.FirstOrDefaultAsync(a => a.Id == id) ?? new ProductQuantity();
        }

        public async Task<IEnumerable<ProductQuantity>> Find(string searchStr = "")
        {
            var result = from pq in appDBContext.ProductQuantities
                         join p in appDBContext.Products on pq.ProductId equals p.Id
                         where p.Name.Contains(searchStr)
                         select pq;
            return await result.ToListAsync();
        }

        public async Task<int> Create(ProductQuantity productQuantity)
        {
            if (productQuantity == null)
                throw new ArgumentNullException();

            appDBContext.ProductQuantities.Add(productQuantity);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(ProductQuantity productQuantity)
        {
            if (productQuantity == null)
                return 0;

            appDBContext.ProductQuantities.Update(productQuantity);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            ProductQuantity? productQuantity = await appDBContext.ProductQuantities.FindAsync(id);
            if (productQuantity == null)
                return 0;

            appDBContext.ProductQuantities.Remove(productQuantity);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
