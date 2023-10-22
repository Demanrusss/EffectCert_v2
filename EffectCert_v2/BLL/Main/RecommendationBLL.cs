using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Implementations.Main;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using Microsoft.IdentityModel.Tokens;

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

        public async Task<ICollection<Recommendation>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await recommendationDAL.Find(searchStr);
        }

        public async Task<ICollection<Recommendation>> FindAll()
        {
            return await recommendationDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await recommendationDAL.Delete(id);
        }
    }
}
