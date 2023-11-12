using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Implementations.Main;
using EffectCert.ViewMappers.Main;
using EffectCert.ViewModels.Main;

namespace EffectCert.BLL.Main
{
    public class AppDecisionBLL : ICommonBLL<AppDecisionViewModel>
    {
        private readonly AppDecisionRepo appDecisionDAL;

        public AppDecisionBLL (AppDecisionRepo appDecisionDAL)
        {
            this.appDecisionDAL = appDecisionDAL;
        }

        public async Task<AppDecisionViewModel> Get(int id)
        {
            var appDecision = await appDecisionDAL.Get(id);

            return AppDecisionMapper.MapToViewModel(appDecision);
        }

        public async Task<int> UpdateOrCreate(AppDecisionViewModel appDecisionVM)
        {
            var appDecision = AppDecisionMapper.MapToModel(appDecisionVM);

            return appDecision.Id == 0 
                ? await appDecisionDAL.Create(appDecision) 
                : await appDecisionDAL.Update(appDecision);
        }

        public async Task<ICollection<AppDecisionViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var appDecisions = await appDecisionDAL.Find(searchStr);

            return ConvertCollection(appDecisions);
        }

        public async Task<ICollection<AppDecisionViewModel>> FindAll()
        {
            var appDecisions = await appDecisionDAL.GetAll();

            return ConvertCollection(appDecisions);
        }

        public async Task<int> Delete(int id)
        {
            return await appDecisionDAL.Delete(id);
        }

        private ICollection<AppDecisionViewModel> ConvertCollection(ICollection<AppDecision> collection)
        {
            var collectionVM = new List<AppDecisionViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(AppDecisionMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
