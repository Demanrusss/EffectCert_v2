using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Others
{
    public class CertObjectRepo : IRepository<CertObject>
    {
        private readonly AppDBContext appDBContext;

        public CertObjectRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<IEnumerable<CertObject>> GetAll()
        {
            return await appDBContext.CertObjects.ToListAsync();
        }

        public async Task<CertObject> Get(int id)
        {
            return await appDBContext.CertObjects.FirstOrDefaultAsync(a => a.Id == id) ?? new CertObject();
        }

        public async Task<IEnumerable<CertObject>> Find(string searchStr = "")
        {
            var result = appDBContext.CertObjects.Where(c => c.Name.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(CertObject certObject)
        {
            if (certObject == null)
                throw new ArgumentNullException();

            appDBContext.CertObjects.Add(certObject);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(CertObject certObject)
        {
            if (certObject == null)
                return 0;

            appDBContext.CertObjects.Update(certObject);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            CertObject? certObject = await appDBContext.CertObjects.FindAsync(id);
            if (certObject == null)
                return 0;

            appDBContext.CertObjects.Remove(certObject);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
