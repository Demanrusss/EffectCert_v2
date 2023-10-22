using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.BLL;
using Microsoft.IdentityModel.Tokens;

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

        public async Task<ICollection<LaboratoryEmployee>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await laboratoryEmployeeDAL.Find(searchStr);
        }

        public async Task<ICollection<LaboratoryEmployee>> FindAll()
        {
            return await laboratoryEmployeeDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await laboratoryEmployeeDAL.Delete(id);
        }
    }
}
