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

        public async Task<ICollection<ProductQuantity>> GetAll()
        {
            return await appDBContext.ProductQuantities
                .Include(pq => pq.Product)
                .Include(pq => pq.MeasurementUnit)
                .Select(pq => new ProductQuantity
                {
                    Id = pq.Id,
                    ProductId = pq.ProductId,
                    Product = new Product
                    {
                        Name = pq.Product.Name,
                        Model = pq.Product.Model
                    },
                    Quantity = pq.Quantity,
                    MeasurementUnitId = pq.MeasurementUnitId,
                    MeasurementUnit = new MeasurementUnit
                    {
                        ShortName = pq.MeasurementUnit.ShortName
                    },
                    MadeDate = pq.MadeDate
                })
                .ToListAsync();
        }

        public async Task<ProductQuantity> Get(int id)
        {
            return await appDBContext.ProductQuantities
                .Include(pq => pq.Product)
                .Include(pq => pq.MeasurementUnit)
                .FirstOrDefaultAsync(a => a.Id == id) ?? new ProductQuantity();
        }

        public async Task<ICollection<ProductQuantity>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.ProductQuantities
                .Include(pq => pq.Product)
                .Include(pq => pq.MeasurementUnit)
                .Where(pq => pq.Product.Name.Contains(searchStr))
                .Select(pq => new ProductQuantity
                {
                    Id = pq.Id,
                    ProductId = pq.ProductId,
                    Product = new Product
                    {
                        Name = pq.Product.Name
                    },
                    Quantity = pq.Quantity,
                    MeasurementUnitId = pq.MeasurementUnitId,
                    MeasurementUnit = new MeasurementUnit
                    {
                        ShortName = pq.MeasurementUnit.ShortName
                    },
                    MadeDate = pq.MadeDate
                })
                .ToListAsync();
        }

        public async Task<int> Create(ProductQuantity productQuantity)
        {
            if (productQuantity == null)
                return 0;

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
