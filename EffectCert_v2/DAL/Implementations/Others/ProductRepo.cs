using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Others
{
    public class ProductRepo : IRepository<Product>
    {
        private readonly AppDBContext appDBContext;

        public ProductRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<Product>> GetAll()
        {
            return await appDBContext.Products.ToListAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await appDBContext.Products.FirstOrDefaultAsync(a => a.Id == id) ?? new Product();
        }

        public async Task<ICollection<Product>> Find(string searchStr = "")
        {
            var result = appDBContext.Products.Where(c => c.Name.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<ICollection<Product>> FindByGroupName(string searchStr = "")
        {
            var result = appDBContext.Products.Where(c => c.GroupName != null ? c.GroupName.Contains(searchStr) : false);
            return await result.ToListAsync();
        }

        public async Task<ICollection<Product>> FindByType(string searchStr = "")
        {
            var result = appDBContext.Products.Where(c => c.Type != null ? c.Type.Contains(searchStr) : false);
            return await result.ToListAsync();
        }

        public async Task<ICollection<Product>> FindByModel(string searchStr = "")
        {
            var result = appDBContext.Products.Where(c => c.Model != null ? c.Model.Contains(searchStr) : false);
            return await result.ToListAsync();
        }

        public async Task<ICollection<Product>> FindByTradeMark(string searchStr = "")
        {
            var result = appDBContext.Products.Where(c => c.TradeMark != null ? c.TradeMark.Contains(searchStr) : false);
            return await result.ToListAsync();
        }

        public async Task<int> Create(Product product)
        {
            if (product == null)
                throw new ArgumentNullException();

            appDBContext.Products.Add(product);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(Product product)
        {
            if (product == null)
                return 0;

            appDBContext.Products.Update(product);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Product? product = await appDBContext.Products.FindAsync(id);
            if (product == null)
                return 0;

            appDBContext.Products.Remove(product);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
