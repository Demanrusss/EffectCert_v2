using EffectCert.BLL.Interfaces;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Implementations.Main;
using EffectCert.ViewMappers.Main;
using EffectCert.ViewModels.Main;

namespace EffectCert.BLL.Main
{
    public class RecommendationBLL : IRecommendationBLL
    {
        private readonly RecommendationRepo recommendationDAL;

        public RecommendationBLL (RecommendationRepo recommendationDAL)
        {
            this.recommendationDAL = recommendationDAL;
        }

        public async Task<RecommendationViewModel> Get(int id)
        {
            var recommendation = await recommendationDAL.Get(id);

            return RecommendationMapper.MapToViewModel(recommendation);
        }

        public async Task<int> UpdateOrCreate(RecommendationViewModel recommendationVM)
        {
            var recommendation = RecommendationMapper.MapToModel(recommendationVM);

            return recommendation.Id == 0 
                ? await recommendationDAL.Create(recommendation) 
                : await recommendationDAL.Update(recommendation);
        }

        public async Task<ICollection<RecommendationViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var recommendations = await recommendationDAL.Find(searchStr);

            return ConvertCollection(recommendations);
        }

        public async Task<ICollection<RecommendationViewModel>> FindAll()
        {
            var recommendations = await recommendationDAL.GetAll();

            return ConvertCollection(recommendations);
        }

        public async Task<int> Delete(int id)
        {
            return await recommendationDAL.Delete(id);
        }

        private ICollection<RecommendationViewModel> ConvertCollection(ICollection<Recommendation> collection)
        {
            var collectionVM = new List<RecommendationViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(RecommendationMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
