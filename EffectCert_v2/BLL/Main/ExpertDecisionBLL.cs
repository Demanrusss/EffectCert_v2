using EffectCert.BLL.Interfaces;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Implementations.Main;
using EffectCert.ViewMappers.Main;
using EffectCert.ViewModels.Main;

namespace EffectCert.BLL.Main
{
    public class ExpertDecisionBLL : IExpertDecisionBLL
    {
        private readonly ExpertDecisionRepo expertDecisionDAL;

        public ExpertDecisionBLL (ExpertDecisionRepo expertDecisionDAL)
        {
            this.expertDecisionDAL = expertDecisionDAL;
        }

        public async Task<ExpertDecisionViewModel> Get(int id)
        {
            var expertDecision = await expertDecisionDAL.Get(id);

            return ExpertDecisionMapper.MapToViewModel(expertDecision);
        }

        public async Task<int> UpdateOrCreate(ExpertDecisionViewModel expertDecisionVM)
        {
            var expertDecision = ExpertDecisionMapper.MapToModel(expertDecisionVM);

            return expertDecision.Id == 0 
                ? await expertDecisionDAL.Create(expertDecision) 
                : await expertDecisionDAL.Update(expertDecision);
        }

        public async Task<ICollection<ExpertDecisionViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var expertDecisions = await expertDecisionDAL.Find(searchStr);

            return ConvertCollection(expertDecisions);
        }

        public async Task<ICollection<ExpertDecisionViewModel>> FindAll()
        {
            var expertDecisions = await expertDecisionDAL.GetAll();

            return ConvertCollection(expertDecisions);
        }

        public async Task<int> Delete(int id)
        {
            return await expertDecisionDAL.Delete(id);
        }

        private ICollection<ExpertDecisionViewModel> ConvertCollection(ICollection<ExpertDecision> collection)
        {
            var collectionVM = new List<ExpertDecisionViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(ExpertDecisionMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
