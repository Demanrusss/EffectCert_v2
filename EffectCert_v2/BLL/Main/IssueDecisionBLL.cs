using EffectCert.BLL.Interfaces;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Implementations.Main;
using EffectCert.ViewMappers.Main;
using EffectCert.ViewModels.Main;

namespace EffectCert.BLL.Main
{
    public class IssueDecisionBLL : ICommonBLL<IssueDecisionViewModel>
    {
        private readonly IssueDecisionRepo issueDecisionDAL;

        public IssueDecisionBLL (IssueDecisionRepo issueDecisionDAL)
        {
            this.issueDecisionDAL = issueDecisionDAL;
        }

        public async Task<IssueDecisionViewModel> Get(int id)
        {
            var issueDecision = await issueDecisionDAL.Get(id);

            return IssueDecisionMapper.MapToViewModel(issueDecision);
        }

        public async Task<int> UpdateOrCreate(IssueDecisionViewModel issueDecisionVM)
        {
            var issueDecision = IssueDecisionMapper.MapToModel(issueDecisionVM);

            return issueDecision.Id == 0 
                ? await issueDecisionDAL.Create(issueDecision) 
                : await issueDecisionDAL.Update(issueDecision);
        }

        public async Task<ICollection<IssueDecisionViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var issueDecisions = await issueDecisionDAL.Find(searchStr);

            return ConvertCollection(issueDecisions);
        }

        public async Task<ICollection<IssueDecisionViewModel>> FindAll()
        {
            var issueDecisions = await issueDecisionDAL.GetAll();

            return ConvertCollection(issueDecisions);
        }

        public async Task<int> Delete(int id)
        {
            return await issueDecisionDAL.Delete(id);
        }

        private ICollection<IssueDecisionViewModel> ConvertCollection(ICollection<IssueDecision> collection)
        {
            var collectionVM = new List<IssueDecisionViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(IssueDecisionMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
