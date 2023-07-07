using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Main
{
    public class ApplicationRepo : IRepository<Application>
    {
        private readonly AppDBContext appDBContext;

        public ApplicationRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<IEnumerable<Application>> GetAll()
        {
            return await appDBContext.Applications.ToListAsync();
        }

        public async Task<Application> Get(int id)
        {
            return await appDBContext.Applications.FirstOrDefaultAsync(a => a.Id == id) ?? new Application();
        }

        public async Task<IEnumerable<Application>> Find(string searchStr = "")
        {
            var result = appDBContext.Applications.Where(c => c.Number.Contains(searchStr));

            return await result.ToListAsync();
        }

        public async Task<int> Create(Application application)
        {
            if (application == null)
                throw new ArgumentNullException();

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
