using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Entities.Documents;
using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities;
using System.Linq;

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
                .Include(a => a.ProductQuantities)
                    .ThenInclude(pq => pq.Product)
                .Include(a => a.ProductQuantities)
                    .ThenInclude(pq => pq.MeasurementUnit)
                .Select(a => new Application
                {
                    Id = a.Id,
                    Number = a.Number,
                    Date = a.Date,
                    ContractorLegal = new ContractorLegal
                    {
                        ShortName = a.ContractorLegal.ShortName
                    },
                    Schema = new Schema
                    {
                        Name = a.Schema.Name
                    },
                    Products = a.Products.Select(p => new Product
                    {
                        Name = p.Name,
                        Model = p.Model
                    }).ToList(),
                    ProductQuantities = a.ProductQuantities.Select(pq => new ProductQuantity
                    { 
                        Product = new Product
                        {
                            Name = pq.Product.Name,
                            Model = pq.Product.Model
                        },
                        Quantity = pq.Quantity,
                        MeasurementUnit = new MeasurementUnit
                        {
                            ShortName = pq.MeasurementUnit.ShortName
                        }
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<Application> Get(int id)
        {
            var application = await appDBContext.Applications
                .Include(a => a.AssessBody)
                .Include(a => a.ContractorLegal)
                .Include(a => a.Schema)
                .Include(a => a.Products)
                .Include(a => a.ProductQuantities)
                .Include(a => a.TechRegs)
                .Select(a => new Application
                {
                    Id = a.Id,
                    Number = a.Number,
                    Date = a.Date,
                    ElectronicNumber = a.ElectronicNumber,
                    ElectronicDate = a.ElectronicDate,
                    AssessBody = new AssessBody
                    {
                        Id = a.Id,
                        ShortName = a.AssessBody.ShortName
                    },
                    ContractorLegal = new ContractorLegal
                    {
                        Id = a.Id,
                        ShortName = a.ContractorLegal.ShortName
                    },
                    Schema = new Schema
                    {
                        Id = a.Id,
                        Name = a.Schema.Name
                    },
                    Products = a.Products.Select(p => new Product
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Model = p.Model
                    }).ToList(),
                    ProductQuantities = a.ProductQuantities.Select(pq => new ProductQuantity
                    {
                        Id = pq.Id,
                        Product = new Product
                        {
                            Name = pq.Product.Name,
                            Model = pq.Product.Model
                        }
                    }).ToList()
                })
                .FirstOrDefaultAsync(a => a.Id == id) ?? new Application();

            var techRegParagraphs = await appDBContext.ApplicationsTechRegs
                .Include(atr => atr.TechReg)
                .Where(atr => atr.ApplicationId == id)
                .Select(atr => new TechRegParagraphs
                {
                    TechRegId = atr.TechRegId,
                    TechReg = new TechReg
                    {
                        Id = atr.TechReg!.Id,
                        ShortName = atr.TechReg!.ShortName
                    },
                    Paragraphs = atr.Paragraphs
                })
                .ToListAsync();

            application.TechRegs = (ICollection<TechRegParagraphs>)techRegParagraphs;

            return application;
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

            var appProductsIds = GetIdsCollectionOf(application.Products);
            var appProductQuantitiesIds = GetIdsCollectionOf(application.ProductQuantities);
            var appTechRegs = new Dictionary<int, string>();
            foreach (var techReg in application.TechRegs)
                appTechRegs.Add(techReg.TechRegId, techReg.Paragraphs ?? String.Empty);

            application.Products = new HashSet<Product>();
            application.ProductQuantities = new HashSet<ProductQuantity>();
            application.TechRegs = new HashSet<TechRegParagraphs>();

            appDBContext.Applications.Add(application);
            await appDBContext.SaveChangesAsync();

            foreach (var product in appProductsIds)
                appDBContext.ApplicationsProducts.Add(new ApplicationsProducts() { ApplicationId = application.Id, ProductId = product });

            foreach (var productQuantity in appProductQuantitiesIds)
                appDBContext.ApplicationsProductQuantities.Add(new ApplicationsProductQuantities() { ApplicationId = application.Id, ProductQuantityId = productQuantity });

            foreach (var techReg in appTechRegs)
                appDBContext.ApplicationsTechRegs.Add(new ApplicationsTechRegs() { ApplicationId = application.Id, TechRegId = techReg.Key, Paragraphs = techReg.Value });

            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(Application application)
        {
            if (application == null)
                return 0;

            var appProductsIds = GetIdsCollectionOf(application.Products);
            var appProductQuantitiesIds = GetIdsCollectionOf(application.ProductQuantities);
            var appTechRegs = new Dictionary<int, string>();
            foreach (var techReg in application.TechRegs)
                appTechRegs.Add(techReg.TechRegId, techReg.Paragraphs ?? String.Empty);

            application.Products = new HashSet<Product>();
            application.ProductQuantities = new HashSet<ProductQuantity>();
            application.TechRegs = new HashSet<TechRegParagraphs>();
            appDBContext.Applications.Update(application);

            IEnumerable<int> existedAPProductsIds = appDBContext.ApplicationsProducts
                .Where(ap => ap.ApplicationId == application.Id)
                .Select(ap => ap.ProductId);

            foreach (var productToAddId in appProductsIds.Except(existedAPProductsIds))
                appDBContext.ApplicationsProducts.Add(new ApplicationsProducts() { ApplicationId = application.Id, ProductId = productToAddId });

            foreach (var id in existedAPProductsIds.Except(appProductsIds))
                appDBContext.ApplicationsProducts.Remove(new ApplicationsProducts() { ApplicationId = application.Id, ProductId = id });

            IEnumerable<int> existedAPProductQuantitiesIds = appDBContext.ApplicationsProductQuantities
                .Where(ap => ap.ApplicationId == application.Id)
                .Select(ap => ap.ProductQuantityId);

            foreach (var productQuantityToAddId in appProductQuantitiesIds.Except(existedAPProductQuantitiesIds))
                appDBContext.ApplicationsProductQuantities.Add(new ApplicationsProductQuantities() { ApplicationId = application.Id, ProductQuantityId = productQuantityToAddId });

            foreach (var id in existedAPProductQuantitiesIds.Except(appProductQuantitiesIds))
                appDBContext.ApplicationsProductQuantities.Remove(new ApplicationsProductQuantities() { ApplicationId = application.Id, ProductQuantityId = id });

            IEnumerable<KeyValuePair<int, string>> existedAPTechRegsIds = appDBContext.ApplicationsTechRegs
                .Where(ap => ap.ApplicationId == application.Id)
                .Select(ap => new KeyValuePair<int, string>(ap.TechRegId, ap.Paragraphs ?? String.Empty));

            foreach (var techRegToAdd in appTechRegs.Except(existedAPTechRegsIds))
                appDBContext.ApplicationsTechRegs.Add(new ApplicationsTechRegs() { ApplicationId = application.Id, TechRegId = techRegToAdd.Key, Paragraphs = techRegToAdd.Value });

            foreach (var techRegToRemove in existedAPTechRegsIds.Except(appTechRegs))
                appDBContext.ApplicationsTechRegs.Remove(new ApplicationsTechRegs() { ApplicationId = application.Id, TechRegId = techRegToRemove.Key });

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

        private ICollection<int> GetIdsCollectionOf<T>(ICollection<T> entities) where T : IEntity
        {
            var ids = new HashSet<int>();
            foreach (var entity in entities)
                ids.Add(entity.Id);

            return ids;
        }
    }
}
