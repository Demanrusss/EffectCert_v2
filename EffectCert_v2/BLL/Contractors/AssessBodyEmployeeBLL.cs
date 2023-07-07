using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.BLL;

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

        public async Task<IEnumerable<AssessBodyEmployee>> Find(string searchStr)
        {
            return await assessBodyEmployeeDAL.Find(searchStr);
        }
    }
}
