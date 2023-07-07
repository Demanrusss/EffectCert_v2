using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.BLL;

namespace EffectCert.BLL.Contractors
{
    public class LaboratoryEmployeeBLL : ICommonBLL<LaboratoryEmployee>
    {
        private readonly LaboratoryEmployeeRepo laboratoryEmployeeDAL;

        public LaboratoryEmployeeBLL(LaboratoryEmployeeRepo laboratoryEmployeeDAL)
        {
            this.laboratoryEmployeeDAL = laboratoryEmployeeDAL;
        }

        public async Task<LaboratoryEmployee> Get(int id)
        {
            return await laboratoryEmployeeDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(LaboratoryEmployee laboratoryEmployee)
        {
            return laboratoryEmployee.Id == 0 
                ? await laboratoryEmployeeDAL.Create(laboratoryEmployee) 
                : await laboratoryEmployeeDAL.Update(laboratoryEmployee);
        }

        public async Task<IEnumerable<LaboratoryEmployee>> Find(string searchStr)
        {
            return await laboratoryEmployeeDAL.Find(searchStr);
        }
    }
}
