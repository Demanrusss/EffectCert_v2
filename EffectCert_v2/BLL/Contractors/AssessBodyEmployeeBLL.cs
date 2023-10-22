using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.BLL;
using Microsoft.IdentityModel.Tokens;

namespace EffectCert.BLL.Contractors
{
    public class AssessBodyEmployeeBLL : ICommonBLL<AssessBodyEmployee>
    {
        private readonly AssessBodyEmployeeRepo assessBodyEmployeeDAL;

        public AssessBodyEmployeeBLL(AssessBodyEmployeeRepo assessBodyEmployeeDAL)
        {
            this.assessBodyEmployeeDAL = assessBodyEmployeeDAL;
        }

        public async Task<AssessBodyEmployee> Get(int id)
        {
            return await assessBodyEmployeeDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(AssessBodyEmployee assessBodyEmployee)
        {
            return assessBodyEmployee.Id == 0 
                ? await assessBodyEmployeeDAL.Create(assessBodyEmployee) 
                : await assessBodyEmployeeDAL.Update(assessBodyEmployee);
        }

        public async Task<ICollection<AssessBodyEmployee>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await assessBodyEmployeeDAL.Find(searchStr);
        }

        public async Task<ICollection<AssessBodyEmployee>> FindAll()
        {
            return await assessBodyEmployeeDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await assessBodyEmployeeDAL.Delete(id);
        }
    }
}
