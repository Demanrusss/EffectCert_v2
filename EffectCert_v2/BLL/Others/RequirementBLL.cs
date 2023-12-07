using EffectCert.BLL.Interfaces;
using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.ViewMappers.Others;
using EffectCert.ViewModels.Others;

namespace EffectCert.BLL.Others
{
    public class RequirementBLL : IRequirementBLL
    {
        private readonly RequirementRepo requirementDAL;

        public RequirementBLL(RequirementRepo requirementDAL)
        {
            this.requirementDAL = requirementDAL;
        }

        public async Task<RequirementViewModel> Get(int id)
        {
            var requirement = await requirementDAL.Get(id);

            return RequirementMapper.MapToViewModel(requirement);
        }

        public async Task<int> UpdateOrCreate(RequirementViewModel requirementVM)
        {
            var requirement = RequirementMapper.MapToModel(requirementVM);

            return requirement.Id == 0
                ? await requirementDAL.Create(requirement)
                : await requirementDAL.Update(requirement);
        }

        public async Task<ICollection<RequirementViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var requirements = await requirementDAL.Find(searchStr);

            return ConvertCollection(requirements);
        }

        public async Task<ICollection<RequirementViewModel>> FindAll()
        {
            var requirements = await requirementDAL.GetAll();

            return ConvertCollection(requirements);
        }

        public async Task<int> Delete(int id)
        {
            return await requirementDAL.Delete(id);
        }

        private ICollection<RequirementViewModel> ConvertCollection(ICollection<Requirement> collection)
        {
            var collectionVM = new List<RequirementViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(RequirementMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
