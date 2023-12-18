using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Others;

namespace EffectCert.DAL.Implementations.Main
{
    public class ApplicationRepo : IRepository<Application>
    {
        private readonly AppDBContext appDBContext;

        public ApplicationRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<Application>> GetAll()
        {
            return await appDBContext.Applications
                .Include(a => a.ContractorLegal)
                .Include(a => a.Schema)
                .Include(a => a.Products)
                .Select(a => new Application
                {
                    Id = a.Id,
                    Number = a.Number,
                    Date = a.Date,
                    ContractorLegalId = a.ContractorLegalId,
                    ContractorLegal = new ContractorLegal
                    {
                        ShortName = a.ContractorLegal.ShortName
                    },
                    SchemaId = a.SchemaId,
                    Schema = new Schema
                    {
                        Name = a.Schema.Name
                    },
                    Products = a.Products.Select(p => new Product
                    {
                        Name = p.Name,
                        Model = p.Model
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<Application> Get(int id)
        {
            return await appDBContext.Applications
                .Include(a => a.AssessBody)
                .Include(a => a.ContractorLegal)
                .Include(a => a.Schema)
                .Include(a => a.Products)
                .Include(a => a.ProductQuantities)
                .FirstOrDefaultAsync(a => a.Id == id) ?? new Application();
        }

        public async Task<ICollection<Application>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.Applications
                .Include(a => a.ContractorLegal)
                .Include(a => a.Schema)
                .Include(a => a.Products)
                .Include(a => a.ProductQuantities)
                .Where(a => a.Number.Contains(searchStr))
                .Select(a => new Application
                {
                    Number = a.Number,
                    Date = a.Date,
                    ContractorLegalId = a.ContractorLegalId,
                    ContractorLegal = new ContractorLegal
                    {
                        ShortName = a.ContractorLegal.ShortName
                    },
                    SchemaId = a.SchemaId,
                    Schema = new Schema
                    {
                        Name = a.Schema.Name
                    },
                    Products = a.Products.Select(p => new Product
                    {
                        Name = p.Name,
                        Model = p.Model
                    }).ToList(),
                    ProductQuantities = a.ProductQuantities.Select(p => new ProductQuantity
                    {
                        Product = new Product
                        {
                            Name = p.Product.Name,
                            Model = p.Product.Model
                        }
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<int> Create(Application application)
        {
            if (application == null)
                return 0;

            var appProductsIds = new HashSet<int>();
            foreach (var product in application.Products)
                appProductsIds.Add(product.Id);

            var appProductQuantitiesIds = new HashSet<int>();
            foreach (var productQuantity in application.ProductQuantities)
                appProductQuantitiesIds.Add(productQuantity.Id);

            application.Products = new HashSet<Product>();
            application.ProductQuantities = new HashSet<ProductQuantity>();

            appDBContext.Applications.Add(application);
            await appDBContext.SaveChangesAsync();

            foreach (var product in appProductsIds)
                appDBContext.ApplicationsProducts.Add(new ApplicationsProducts() { ApplicationId = application.Id, ProductId = product });

            foreach (var productQuantity in appProductQuantitiesIds)
                appDBContext.ApplicationsProductQuantities.Add(new ApplicationsProductQuantities() { ApplicationId = application.Id, ProductQuantityId = productQuantity });

            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(Application application)
        {
            if (application == null)
                return 0;

            var appProductsIds = new HashSet<int>();
            foreach (var product in application.Products)
                appProductsIds.Add(product.Id);

            application.Products = new HashSet<Product>();
            appDBContext.Applications.Update(application);

            IEnumerable<int> existedAPProductsIds = appDBContext.ApplicationsProducts.Where(ap => ap.ApplicationId == application.Id).Select(ap => ap.ProductId);

            foreach (var productToAddId in appProductsIds.Except(existedAPProductsIds))
                appDBContext.ApplicationsProducts.Add(new ApplicationsProducts() { ApplicationId = application.Id, ProductId = productToAddId });

            foreach (var id in existedAPProductsIds.Except(appProductsIds))
                appDBContext.ApplicationsProducts.Remove(new ApplicationsProducts() { ApplicationId = application.Id, ProductId = id });

            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Application? application = await appDBContext.Applications.FindAsync(id);
            if (application == null)
                return 0;

            appDBContext.Applications.Remove(application);
            return await appDBContext.SaveChangesAsync();
        }
    }
}
