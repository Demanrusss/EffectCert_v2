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
                        Name = p.Name
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<Application> Get(int id)
        {
            return await appDBContext.Applications.FirstOrDefaultAsync(a => a.Id == id) ?? new Application();
        }

        public async Task<ICollection<Application>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.Applications
                .Include(a => a.ContractorLegal)
                .Include(a => a.Schema)
                .Include(a => a.Products)
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
                        Name = p.Name
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<int> Create(Application application)
        {
            if (application == null)
                return 0;

            appDBContext.Applications.Add(application);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(Application application)
        {
            if (application == null)
                return 0;

            appDBContext.Applications.Update(application);
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
