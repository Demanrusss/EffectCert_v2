using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Documents
{
    public class TechRegRepo : IRepository<TechReg>
    {
        private readonly AppDBContext appDBContext;

        public TechRegRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<TechReg>> GetAll()
        {
            return await appDBContext.TechRegs.ToListAsync();
        }

        public async Task<TechReg> Get(int id)
        {
            return await appDBContext.TechRegs.FirstOrDefaultAsync(a => a.Id == id) ?? new TechReg();
        }

        public async Task<ICollection<TechReg>> Find(string searchStr = "")
        {
            var result = appDBContext.TechRegs.Where(c => c.Number.Contains(searchStr)
                                                          || c.Name.Contains(searchStr)
                                                          || c.ShortName.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(TechReg techReg)
        {
            if (techReg == null)
                throw new ArgumentNullException();

            appDBContext.TechRegs.Add(techReg);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(TechReg techReg)
        {
            if (techReg == null)
                return 0;

            appDBContext.TechRegs.Update(techReg);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            TechReg? techReg = await appDBContext.TechRegs.FindAsync(id);
            if (techReg == null)
                return 0;

            appDBContext.TechRegs.Remove(techReg);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
