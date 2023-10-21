using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

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
            return await appDBContext.SelectProductsActs.ToListAsync();
        }

        public async Task<SelectProductsAct> Get(int id)
        {
            return await appDBContext.SelectProductsActs.FirstOrDefaultAsync(a => a.Id == id) ?? new SelectProductsAct();
        }

        public async Task<ICollection<SelectProductsAct>> Find(string searchStr = "")
        {
            var result = appDBContext.SelectProductsActs.Where(c => c.Number.Contains(searchStr));

            return await result.ToListAsync();
        }

        public async Task<int> Create(SelectProductsAct selectProductsAct)
        {
            if (selectProductsAct == null)
                throw new ArgumentNullException();

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
