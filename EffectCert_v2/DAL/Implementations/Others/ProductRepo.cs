using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;
using EffectCert.DAL.Entities.Contractors;

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
            return await appDBContext.Products
                .Include(p => p.Manufacturer)
                .Select(p => new Product
                {
                    ManufacturerId = p.ManufacturerId,
                    Manufacturer = new ContractorLegal
                    {
                        ShortName = p.Manufacturer.ShortName
                    },
                    Id = p.Id,
                    Model = p.Model,
                    Name = p.Name,
                    TNVED = p.TNVED
                })
                .ToListAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await appDBContext.Products.FirstOrDefaultAsync(a => a.Id == id) ?? new Product();
        }

        public async Task<ICollection<Product>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.Products
                .Include(p => p.Manufacturer)
                .Where(p => p.Name.Contains(searchStr))
                .Select(p => new Product
                {
                    ManufacturerId = p.ManufacturerId,
                    Manufacturer = new ContractorLegal
                    {
                        ShortName = p.Manufacturer.ShortName
                    },
                    Id = p.Id,
                    Model = p.Model,
                    Name = p.Name,
                    TNVED = p.TNVED
                })
                .ToListAsync();
        }

        public async Task<ICollection<Product>> FindByGroupName(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.Products
                .Include(p => p.Manufacturer)
                .Where(p => p.GroupName!.Contains(searchStr))
                .Select(p => new Product
                {
                    ManufacturerId = p.ManufacturerId,
                    Manufacturer = new ContractorLegal
                    {
                        ShortName = p.Manufacturer.ShortName
                    },
                    Id = p.Id,
                    Model = p.Model,
                    Name = p.Name,
                    TNVED = p.TNVED
                })
                .ToListAsync();
        }

        public async Task<ICollection<Product>> FindByType(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.Products
                .Include(p => p.Manufacturer)
                .Where(p => p.Type!.Contains(searchStr))
                .Select(p => new Product
                {
                    ManufacturerId = p.ManufacturerId,
                    Manufacturer = new ContractorLegal
                    {
                        ShortName = p.Manufacturer.ShortName
                    },
                    Id = p.Id,
                    Model = p.Model,
                    Name = p.Name,
                    TNVED = p.TNVED
                })
                .ToListAsync();
        }

        public async Task<ICollection<Product>> FindByModel(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.Products
                .Include(p => p.Manufacturer)
                .Where(p => p.Model!.Contains(searchStr))
                .Select(p => new Product
                {
                    ManufacturerId = p.ManufacturerId,
                    Manufacturer = new ContractorLegal
                    {
                        ShortName = p.Manufacturer.ShortName
                    },
                    Id = p.Id,
                    Model = p.Model,
                    Name = p.Name,
                    TNVED = p.TNVED
                })
                .ToListAsync();
        }

        public async Task<ICollection<Product>> FindByTradeMark(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.Products
                .Include(p => p.Manufacturer)
                .Where(p => p.TradeMark!.Contains(searchStr))
                .Select(p => new Product
                {
                    ManufacturerId = p.ManufacturerId,
                    Manufacturer = new ContractorLegal
                    {
                        ShortName = p.Manufacturer.ShortName
                    },
                    Id = p.Id,
                    Model = p.Model,
                    Name = p.Name,
                    TNVED = p.TNVED
                })
                .ToListAsync();
        }

        public async Task<int> Create(Product product)
        {
            if (product == null)
                return 0;

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
