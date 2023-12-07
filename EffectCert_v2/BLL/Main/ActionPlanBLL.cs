using EffectCert.BLL.Interfaces;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Implementations.Main;
using EffectCert.ViewMappers.Main;
using EffectCert.ViewModels.Main;

namespace EffectCert.BLL.Main
{
    public class ActionPlanBLL : IActionPlanBLL
    {
        private readonly ActionPlanRepo actionPlanDAL;

        public ActionPlanBLL (ActionPlanRepo testProtocolDAL)
        {
            this.actionPlanDAL = testProtocolDAL;
        }

        public async Task<ActionPlanViewModel> Get(int id)
        {
            var actionPlan = await actionPlanDAL.Get(id);

            return ActionPlanMapper.MapToViewModel(actionPlan);
        }

        public async Task<int> UpdateOrCreate(ActionPlanViewModel actionPlanVM)
        {
            var actionPlan = ActionPlanMapper.MapToModel(actionPlanVM);

            return actionPlan.Id == 0 
                ? await actionPlanDAL.Create(actionPlan) 
                : await actionPlanDAL.Update(actionPlan);
        }

        public async Task<ICollection<ActionPlanViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var actionPlans = await actionPlanDAL.Find(searchStr);

            return ConvertCollection(actionPlans);
        }

        public async Task<ICollection<ActionPlanViewModel>> FindAll()
        {
            var actionPlans = await actionPlanDAL.GetAll();

            return ConvertCollection(actionPlans);
        }

        public async Task<int> Delete(int id)
        {
            return await actionPlanDAL.Delete(id);
        }

        private ICollection<ActionPlanViewModel> ConvertCollection(ICollection<ActionPlan> collection)
        {
            var collectionVM = new List<ActionPlanViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(ActionPlanMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
