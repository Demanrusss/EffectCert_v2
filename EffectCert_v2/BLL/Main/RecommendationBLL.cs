using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Implementations.Main;
using EffectCert.BLL;

namespace EffectCert.BLL.Main
{
    public class RecommendationBLL : ICommonBLL<Recommendation>
    {
        private readonly RecommendationRepo recommendationDAL;

        public RecommendationBLL (RecommendationRepo recommendationDAL)
        {
            this.recommendationDAL = recommendationDAL;
        }

        public async Task<Recommendation> Get(int id)
        {
            return await recommendationDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(Recommendation recommendation)
        {
            return recommendation.Id == 0 
                ? await recommendationDAL.Create(recommendation) 
                : await recommendationDAL.Update(recommendation);
        }

        public async Task<IEnumerable<Recommendation>> Find(string searchStr)
        {
            return await recommendationDAL.Find(searchStr);
        }
    }
}
