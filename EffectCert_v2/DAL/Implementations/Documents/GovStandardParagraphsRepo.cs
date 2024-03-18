using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Documents
{
    public class GovStandardParagraphsRepo : IRepository<GovStandardParagraphs>
    {
        private readonly AppDBContext appDBContext;

        public GovStandardParagraphsRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<GovStandardParagraphs>> GetAll()
        {
            return await appDBContext.GovStandardsParagraphs
                .Include(gsp => gsp.GovStandard)
                .ToListAsync();
        }

        public async Task<GovStandardParagraphs> Get(int id)
        {
            return await appDBContext.GovStandardsParagraphs
                .Include(gsp => gsp.GovStandard)
                .FirstOrDefaultAsync(a => a.Id == id) ?? new GovStandardParagraphs();
        }

        public async Task<ICollection<GovStandardParagraphs>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.GovStandardsParagraphs
                .Include(gsp => gsp.GovStandard)
                .Where(c => c.Paragraphs != null && c.Paragraphs.Contains(searchStr))
                .ToListAsync();
        }

        public async Task<ICollection<GovStandardParagraphs>> FindBy(int govStandardId, string searchStr)
        {
            return await appDBContext.GovStandardsParagraphs
                .Include(gsp => gsp.GovStandard)
                .Where(c => c.GovStandardId == govStandardId)
                .Where(c => c.Paragraphs.Equals(searchStr ?? String.Empty))
                .ToListAsync();
        }

        public async Task<int> Create(GovStandardParagraphs govStandardParagraphs)
        {
            if (govStandardParagraphs == null)
                return 0;

            appDBContext.GovStandardsParagraphs.Add(govStandardParagraphs);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(GovStandardParagraphs govStandardParagraphs)
        {
            if (govStandardParagraphs == null)
                return 0;

            appDBContext.GovStandardsParagraphs.Update(govStandardParagraphs);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            GovStandardParagraphs? govStandardParagraphs = await appDBContext.GovStandardsParagraphs.FindAsync(id);
            if (govStandardParagraphs == null)
                return 0;

            appDBContext.GovStandardsParagraphs.Remove(govStandardParagraphs);
            return await appDBContext.SaveChangesAsync();
        }
    }
}
