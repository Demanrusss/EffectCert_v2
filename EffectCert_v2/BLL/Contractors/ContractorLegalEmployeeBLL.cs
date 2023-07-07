using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.BLL;

namespace EffectCert.BLL.Contractors
{
    public class ContractorLegalEmployeeBLL : ICommonBLL<ContractorLegalEmployee>
    {
        private readonly ContractorLegalEmployeeRepo contractorLegalEmployeeDAL;

        public ContractorLegalEmployeeBLL(ContractorLegalEmployeeRepo contractorLegalEmployeeDAL)
        {
            this.contractorLegalEmployeeDAL = contractorLegalEmployeeDAL;
        }

        public async Task<ContractorLegalEmployee> Get(int id)
        {
            return await contractorLegalEmployeeDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(ContractorLegalEmployee contractorLegalEmployee)
        {
            return contractorLegalEmployee.Id == 0 
                ? await contractorLegalEmployeeDAL.Create(contractorLegalEmployee) 
                : await contractorLegalEmployeeDAL.Update(contractorLegalEmployee);
        }

        public async Task<IEnumerable<ContractorLegalEmployee>> Find(string searchStr)
        {
            return await contractorLegalEmployeeDAL.Find(searchStr);
        }
    }
}
