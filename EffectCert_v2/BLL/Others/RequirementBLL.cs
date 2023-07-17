using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using Microsoft.IdentityModel.Tokens;

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
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await requirementDAL.Find(searchStr);
        }

        public async Task<IEnumerable<Requirement>> FindAll()
        {
            return await requirementDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await requirementDAL.Delete(id);
        }
    }
}
