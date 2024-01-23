using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Implementations.Documents;

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
                .Include(a => a.TechRegsParagraphs)
                .Select(a => new Application
                {
                    Id = a.Id,
                    Number = a.Number,
                    Date = a.Date,
                    ElectronicNumber = a.ElectronicNumber,
                    ElectronicDate = a.ElectronicDate,
                    AssessBody = new AssessBody
                    {
                        Id = a.AssessBody.Id,
                        ShortName = a.AssessBody.ShortName
                    },
                    ContractorLegal = new ContractorLegal
                    {
                        Id = a.ContractorLegal.Id,
                        ShortName = a.ContractorLegal.ShortName
                    },
                    Schema = new Schema
                    {
                        Id = a.Schema.Id,
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
                    }).ToList(),
                    TechRegsParagraphs = a.TechRegsParagraphs.Select(trp => new TechRegParagraphs
                    {
                        Id = trp.Id,
                        TechRegId = trp.TechRegId,
                        TechReg = new TechReg
                        {
                            Id = trp.TechReg!.Id,
                            ShortName = trp.TechReg!.ShortName
                        },
                        Paragraphs = trp.Paragraphs
                    }).ToList()
                })
                .FirstOrDefaultAsync(a => a.Id == id) ?? new Application();

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

            UpdateSubEntitiesWithIds(application.TechRegsParagraphs);
            var appTechRegsParagraphs = GetIdsCollectionOf(application.TechRegsParagraphs);

            application.Products = new HashSet<Product>();
            application.ProductQuantities = new HashSet<ProductQuantity>();
            application.TechRegsParagraphs = new HashSet<TechRegParagraphs>();

            appDBContext.Applications.Add(application);
            await appDBContext.SaveChangesAsync();

            foreach (var product in appProductsIds)
                appDBContext.ApplicationsProducts.Add(new ApplicationsProducts() { ApplicationId = application.Id, ProductId = product });

            foreach (var productQuantity in appProductQuantitiesIds)
                appDBContext.ApplicationsProductQuantities.Add(new ApplicationsProductQuantities() { ApplicationId = application.Id, ProductQuantityId = productQuantity });

            foreach (var techReg in appTechRegsParagraphs)
                appDBContext.ApplicationsTechRegsParagraphs.Add(new ApplicationsTechRegsParagraphs() { ApplicationId = application.Id, TechRegParagraphsId = techReg });

            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(Application application)
        {
            if (application == null)
                return 0;

            UpdateApplicationsProducts(application);
            UpdateApplicationsProductQuantities(application);
            UpdateApplicationsTechRegsParagraphs(application);
            UpdateApplications(application);

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

        

        private void UpdateApplicationsProducts(Application application)
        {
            var appProductsIds = GetIdsCollectionOf(application.Products);

            IEnumerable<int> existedAPProductsIds = appDBContext.ApplicationsProducts
                .Where(ap => ap.ApplicationId == application.Id)
                .Select(ap => ap.ProductId);

            foreach (var productIdToAdd in appProductsIds.Except(existedAPProductsIds))
                appDBContext.ApplicationsProducts.Add(new ApplicationsProducts() 
                { 
                    ApplicationId = application.Id, 
                    ProductId = productIdToAdd 
                });

            foreach (var productIdToRemove in existedAPProductsIds.Except(appProductsIds))
                appDBContext.ApplicationsProducts.Remove(new ApplicationsProducts() 
                { 
                    ApplicationId = application.Id, 
                    ProductId = productIdToRemove 
                });
        }

        private void UpdateApplicationsProductQuantities(Application application)
        {
            var appProductQuantitiesIds = GetIdsCollectionOf(application.ProductQuantities);

            IEnumerable<int> existedAPProductQuantitiesIds = appDBContext.ApplicationsProductQuantities
                .Where(ap => ap.ApplicationId == application.Id)
                .Select(ap => ap.ProductQuantityId);

            foreach (var productQuantityIdToAdd in appProductQuantitiesIds.Except(existedAPProductQuantitiesIds))
                appDBContext.ApplicationsProductQuantities.Add(new ApplicationsProductQuantities() 
                { 
                    ApplicationId = application.Id, 
                    ProductQuantityId = productQuantityIdToAdd 
                });

            foreach (var productQuantityIdToRemove in existedAPProductQuantitiesIds.Except(appProductQuantitiesIds))
                appDBContext.ApplicationsProductQuantities.Remove(new ApplicationsProductQuantities() 
                { 
                    ApplicationId = application.Id, 
                    ProductQuantityId = productQuantityIdToRemove 
                });
        }

        private void UpdateApplicationsTechRegsParagraphs(Application application)
        {
            UpdateSubEntitiesWithIds(application.TechRegsParagraphs);
            var appTechRegsParagraphs = GetIdsCollectionOf(application.TechRegsParagraphs);

            IEnumerable<int> existedAPTechRegsIds = appDBContext.ApplicationsTechRegsParagraphs
                .Where(ap => ap.ApplicationId == application.Id)
                .Select(ap => ap.TechRegParagraphsId);

            foreach (var techRegIdToAdd in appTechRegsParagraphs.Except(existedAPTechRegsIds))
                appDBContext.ApplicationsTechRegsParagraphs.Add(new ApplicationsTechRegsParagraphs()
                {
                    ApplicationId = application.Id,
                    TechRegParagraphsId = techRegIdToAdd
                });

            foreach (var techRegIdToRemove in existedAPTechRegsIds.Except(appTechRegsParagraphs))
                appDBContext.ApplicationsTechRegsParagraphs.Remove(new ApplicationsTechRegsParagraphs()
                {
                    ApplicationId = application.Id,
                    TechRegParagraphsId = techRegIdToRemove
                });
        }

        private void UpdateSubEntitiesWithIds(ICollection<TechRegParagraphs> subEntities)
        {
            var techRegParagraphsRepo = new TechRegParagraphsRepo(appDBContext);

            foreach (var item in subEntities)
            {
                var techRegParagraphs = techRegParagraphsRepo
                    .FindBy(item.TechRegId, item.Paragraphs)
                    .Result
                    .FirstOrDefault();
                item.Id = techRegParagraphs == null ? techRegParagraphsRepo.Create(item).Result : techRegParagraphs.Id;
            }
        }

        private void UpdateApplications(Application application)
        {
            application.Products = new HashSet<Product>();
            application.ProductQuantities = new HashSet<ProductQuantity>();
            application.TechRegsParagraphs = new HashSet<TechRegParagraphs>();
            appDBContext.Applications.Update(application);
        }
    }
}
