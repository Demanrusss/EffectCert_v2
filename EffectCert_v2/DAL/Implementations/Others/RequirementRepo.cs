using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Others
{
    public class RequirementRepo : IRepository<Requirement>
    {
        private readonly AppDBContext appDBContext;

        public RequirementRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<IEnumerable<Requirement>> GetAll()
        {
            return await appDBContext.Requirements.ToListAsync();
        }

        public async Task<Requirement> Get(int id)
        {
            return await appDBContext.Requirements.FirstOrDefaultAsync(a => a.Id == id) ?? new Requirement();
        }

        public async Task<IEnumerable<Requirement>> Find(string searchStr = "")
        {
            var result = appDBContext.Requirements.Where(c => c.Name.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(Requirement requirement)
        {
            if (requirement == null)
                throw new ArgumentNullException();

            appDBContext.Requirements.Add(requirement);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(Requirement requirement)
        {
            if (requirement == null)
                return 0;

            appDBContext.Requirements.Update(requirement);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Requirement? requirement = await appDBContext.Requirements.FindAsync(id);
            if (requirement == null)
                return 0;

            appDBContext.Requirements.Remove(requirement);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
