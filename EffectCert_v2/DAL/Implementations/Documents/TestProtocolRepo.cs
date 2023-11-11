using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

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
            return await appDBContext.TestProtocols.ToListAsync();
        }

        public async Task<TestProtocol> Get(int id)
        {
            return await appDBContext.TestProtocols.FirstOrDefaultAsync(a => a.Id == id) ?? new TestProtocol();
        }

        public async Task<ICollection<TestProtocol>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            var result = appDBContext.TestProtocols.Where(c => c.Number.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(TestProtocol testProtocol)
        {
            if (testProtocol == null)
                throw new ArgumentNullException();

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
