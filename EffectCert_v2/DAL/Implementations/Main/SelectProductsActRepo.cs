using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Others;

namespace EffectCert.DAL.Implementations.Main
{
    public class SelectProductsActRepo : IRepository<SelectProductsAct>
    {
        private readonly AppDBContext appDBContext;

        public SelectProductsActRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<SelectProductsAct>> GetAll()
        {
            return await appDBContext.SelectProductsActs
                .Include(spa => spa.Application)
                .Include(spa => spa.ActionPlan)
                .Include(spa => spa.Supplier)
                .Include(spa => spa.SelectedProducts)
                    .ThenInclude(sp => sp.ProductQuantity)
                        .ThenInclude(pq => pq.Product)
                .Select(spa => new SelectProductsAct
                {
                    Id = spa.Id,
                    Number = spa.Number,
                    Date = spa.Date,
                    ApplicationId = spa.ApplicationId,
                    Application = new Application
                    {
                        Number = spa.Application.Number
                    },
                    ActionPlanId = spa.ActionPlanId,
                    ActionPlan = new ActionPlan
                    {
                        Number = spa.ActionPlan.Number
                    },
                    SupplierId = spa.SupplierId,
                    Supplier = new ContractorLegal
                    {
                        ShortName = spa.Supplier.ShortName
                    },
                    SelectedProducts = spa.SelectedProducts.Select(sp => new SelectedSampleQuantity
                    {
                        ProductQuantity = new ProductQuantity
                        {
                            Product = new Product
                            {
                                Name = sp.ProductQuantity.Product.Name
                            }
                        }
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<SelectProductsAct> Get(int id)
        {
            return await appDBContext.SelectProductsActs.FirstOrDefaultAsync(a => a.Id == id) ?? new SelectProductsAct();
        }

        public async Task<ICollection<SelectProductsAct>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.SelectProductsActs
                .Include(spa => spa.Application)
                .Include(spa => spa.ActionPlan)
                .Include(spa => spa.Supplier)
                .Include(spa => spa.SelectedProducts)
                    .ThenInclude(sp => sp.ProductQuantity)
                        .ThenInclude(pq => pq.Product)
                .Where(spa => spa.Number.Contains(searchStr))
                .Select(spa => new SelectProductsAct
                {
                    Id = spa.Id,
                    Number = spa.Number,
                    Date = spa.Date,
                    ApplicationId = spa.ApplicationId,
                    Application = new Application
                    {
                        Number = spa.Application.Number
                    },
                    ActionPlanId = spa.ActionPlanId,
                    ActionPlan = new ActionPlan
                    {
                        Number = spa.ActionPlan.Number
                    },
                    SupplierId = spa.SupplierId,
                    Supplier = new ContractorLegal
                    {
                        ShortName = spa.Supplier.ShortName
                    },
                    SelectedProducts = spa.SelectedProducts.Select(sp => new SelectedSampleQuantity
                    {
                        ProductQuantity = new ProductQuantity
                        {
                            Product = new Product
                            {
                                Name = sp.ProductQuantity.Product.Name
                            }
                        }
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<int> Create(SelectProductsAct selectProductsAct)
        {
            if (selectProductsAct == null)
                return 0;

            appDBContext.SelectProductsActs.Add(selectProductsAct);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(SelectProductsAct selectProductsAct)
        {
            if (selectProductsAct == null)
                return 0;

            appDBContext.SelectProductsActs.Update(selectProductsAct);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            SelectProductsAct? selectProductsAct = await appDBContext.SelectProductsActs.FindAsync(id);
            if (selectProductsAct == null)
                return 0;

            appDBContext.SelectProductsActs.Remove(selectProductsAct);
            return await appDBContext.SaveChangesAsync();
        }
    }
}
