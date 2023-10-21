using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Documents
{
    public class DeclarationRepo : IRepository<Declaration>
    {
        private readonly AppDBContext appDBContext;

        public DeclarationRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<Declaration>> GetAll()
        {
            return await appDBContext.Declarations.ToListAsync();
        }

        public async Task<Declaration> Get(int id)
        {
            return await appDBContext.Declarations.FirstOrDefaultAsync(a => a.Id == id) ?? new Declaration();
        }

        public async Task<ICollection<Declaration>> Find(string searchStr = "")
        {
            var result = appDBContext.Declarations.Where(c => c.Number.Contains(searchStr) 
                                                           || c.Name.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(Declaration declaration)
        {
            if (declaration == null)
                throw new ArgumentNullException();

            appDBContext.Declarations.Add(declaration);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(Declaration declaration)
        {
            if (declaration == null)
                return 0;

            appDBContext.Declarations.Update(declaration);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Declaration? declaration = await appDBContext.Declarations.FindAsync(id);
            if (declaration == null)
                return 0;

            appDBContext.Declarations.Remove(declaration);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
