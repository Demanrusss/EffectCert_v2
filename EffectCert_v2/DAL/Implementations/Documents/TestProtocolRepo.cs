using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;
using EffectCert.DAL.Entities.Contractors;

namespace EffectCert.DAL.Implementations.Documents
{
    public class TestProtocolRepo : IRepository<TestProtocol>
    {
        private readonly AppDBContext appDBContext;

        public TestProtocolRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<TestProtocol>> GetAll()
        {
            return await appDBContext.TestProtocols
                .Include(tp => tp.Laboratory)
                .Select(tp => new TestProtocol
                {
                    Id = tp.Id,
                    Date = tp.Date,
                    Number = tp.Number,
                    LaboratoryId = tp.LaboratoryId,
                    Laboratory = new Laboratory
                    {
                        ShortName = tp.Laboratory.ShortName
                    }
                })
                .ToListAsync();
        }

        public async Task<TestProtocol> Get(int id)
        {
            return await appDBContext.TestProtocols.FirstOrDefaultAsync(a => a.Id == id) ?? new TestProtocol();
        }

        public async Task<ICollection<TestProtocol>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.TestProtocols
                .Include(tp => tp.Laboratory)
                .Where(tp => tp.Number.Contains(searchStr))
                .Select(tp => new TestProtocol
                {
                    Id = tp.Id,
                    Date = tp.Date,
                    Number = tp.Number,
                    LaboratoryId = tp.LaboratoryId,
                    Laboratory = new Laboratory
                    {
                        ShortName = tp.Laboratory.ShortName
                    }
                })
                .ToListAsync();
        }

        public async Task<int> Create(TestProtocol testProtocol)
        {
            if (testProtocol == null)
                return 0;

            appDBContext.TestProtocols.Add(testProtocol);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(TestProtocol testProtocol)
        {
            if (testProtocol == null)
                return 0;

            appDBContext.TestProtocols.Update(testProtocol);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            TestProtocol? testProtocol = await appDBContext.TestProtocols.FindAsync(id);
            if (testProtocol == null)
                return 0;

            appDBContext.TestProtocols.Remove(testProtocol);
            return await appDBContext.SaveChangesAsync();
        }
    }
}
