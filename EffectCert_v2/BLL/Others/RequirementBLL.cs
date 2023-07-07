using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.BLL;

namespace EffectCert.BLL.Others
{
    public class RequirementBLL : ICommonBLL<Requirement>
    {
        private readonly RequirementRepo requirementDAL;

        public RequirementBLL(RequirementRepo requirementDAL)
        {
            this.requirementDAL = requirementDAL;
        }

        public async Task<Requirement> Get(int id)
        {
            return await requirementDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(Requirement requirement)
        {
            return requirement.Id == 0
                ? await requirementDAL.Create(requirement)
                : await requirementDAL.Update(requirement);
        }

        public async Task<IEnumerable<Requirement>> Find(string searchStr)
        {
            return await requirementDAL.Find(searchStr);
        }
    }
}
