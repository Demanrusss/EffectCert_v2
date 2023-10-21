using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Main
{
    public class ActionPlanRepo : IRepository<ActionPlan>
    {
        private readonly AppDBContext appDBContext;

        public ActionPlanRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<ActionPlan>> GetAll()
        {
            return await appDBContext.ActionPlans.ToListAsync();
        }

        public async Task<ActionPlan> Get(int id)
        {
            return await appDBContext.ActionPlans.FirstOrDefaultAsync(a => a.Id == id) ?? new ActionPlan();
        }

        public async Task<ICollection<ActionPlan>> Find(string searchStr = "")
        {
            var result = appDBContext.ActionPlans.Where(c => c.Number.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(ActionPlan actionPlan)
        {
            if (actionPlan == null)
                throw new ArgumentNullException();

            appDBContext.ActionPlans.Add(actionPlan);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(ActionPlan actionPlan)
        {
            if (actionPlan == null)
                return 0;

            appDBContext.ActionPlans.Update(actionPlan);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            ActionPlan? actionPlan = await appDBContext.ActionPlans.FindAsync(id);
            if (actionPlan == null)
                return 0;

            appDBContext.ActionPlans.Remove(actionPlan);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
