using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Documents
{
    public class TechRegParagraphsRepo : IRepository<TechRegParagraphs>
    {
        private readonly AppDBContext appDBContext;

        public TechRegParagraphsRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<TechRegParagraphs>> GetAll()
        {
            return await appDBContext.TechRegsParagraphs
                .Include(trp => trp.TechReg)
                .ToListAsync();
        }

        public async Task<TechRegParagraphs> Get(int id)
        {
            return await appDBContext.TechRegsParagraphs
                .Include(trp => trp.TechReg)
                .FirstOrDefaultAsync(a => a.Id == id) ?? new TechRegParagraphs();
        }

        public async Task<ICollection<TechRegParagraphs>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.TechRegsParagraphs
                .Include(trp => trp.TechReg)
                .Where(c => c.Paragraphs != null && c.Paragraphs.Contains(searchStr))
                .ToListAsync();
        }

        public async Task<ICollection<TechRegParagraphs>> FindBy(int techRegId, string searchStr)
        {
            return await appDBContext.TechRegsParagraphs
                .Include(trp => trp.TechReg)
                .Where(c => c.TechRegId == techRegId)
                .Where(c => c.Paragraphs != null && c.Paragraphs.Equals(searchStr))
                .ToListAsync();
        }

        public async Task<int> Create(TechRegParagraphs techReg)
        {
            if (techReg == null)
                return 0;

            appDBContext.TechRegsParagraphs.Add(techReg);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(TechRegParagraphs techReg)
        {
            if (techReg == null)
                return 0;

            appDBContext.TechRegsParagraphs.Update(techReg);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            TechRegParagraphs? techReg = await appDBContext.TechRegsParagraphs.FindAsync(id);
            if (techReg == null)
                return 0;

            appDBContext.TechRegsParagraphs.Remove(techReg);
            return await appDBContext.SaveChangesAsync();
        }
    }
}
