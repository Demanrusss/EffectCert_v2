using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Documents
{
    public class CertificateRepo : IRepository<Certificate>
    {
        private readonly AppDBContext appDBContext;

        public CertificateRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<Certificate>> GetAll()
        {
            return await appDBContext.Certificates.ToListAsync();
        }

        public async Task<Certificate> Get(int id)
        {
            return await appDBContext.Certificates.FirstOrDefaultAsync(a => a.Id == id) ?? new Certificate();
        }

        public async Task<ICollection<Certificate>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            var result = appDBContext.Certificates.Where(c => c.Number.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(Certificate certificate)
        {
            if (certificate == null)
                return 0;

            appDBContext.Certificates.Add(certificate);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(Certificate certificate)
        {
            if (certificate == null)
                return 0;

            appDBContext.Certificates.Update(certificate);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Certificate? certificate = await appDBContext.Certificates.FindAsync(id);
            if (certificate == null)
                return 0;

            appDBContext.Certificates.Remove(certificate);
            return await appDBContext.SaveChangesAsync();
        }
    }
}
