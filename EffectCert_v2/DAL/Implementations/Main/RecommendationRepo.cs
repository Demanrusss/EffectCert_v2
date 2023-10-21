using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Main
{
    public class RecommendationRepo : IRepository<Recommendation>
    {
        private readonly AppDBContext appDBContext;

        public RecommendationRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<Recommendation>> GetAll()
        {
            return await appDBContext.Recommendations.ToListAsync();
        }

        public async Task<Recommendation> Get(int id)
        {
            return await appDBContext.Recommendations.FirstOrDefaultAsync(a => a.Id == id) ?? new Recommendation();
        }

        public async Task<ICollection<Recommendation>> Find(string searchStr = "")
        {
            var result = appDBContext.Recommendations.Where(c => c.Number.Contains(searchStr));

            return await result.ToListAsync();
        }

        public async Task<int> Create(Recommendation recommendation)
        {
            if (recommendation == null)
                throw new ArgumentNullException();

            appDBContext.Recommendations.Add(recommendation);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(Recommendation recommendation)
        {
            if (recommendation == null)
                return 0;

            appDBContext.Recommendations.Update(recommendation);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Recommendation? recommendation = await appDBContext.Recommendations.FindAsync(id);
            if (recommendation == null)
                return 0;

            appDBContext.Recommendations.Remove(recommendation);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
