using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.ViewMappers.Contractors;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.BLL.Contractors
{
    public class ContractorLegalEmployeeBLL : ICommonBLL<ContractorLegalEmployeeViewModel>
    {
        private readonly ContractorLegalEmployeeRepo contractorLegalEmployeeDAL;

        public ContractorLegalEmployeeBLL(ContractorLegalEmployeeRepo contractorLegalEmployeeDAL)
        {
            this.contractorLegalEmployeeDAL = contractorLegalEmployeeDAL;
        }

        public async Task<ContractorLegalEmployeeViewModel> Get(int id)
        {
            var contractorLegalEmployee = await contractorLegalEmployeeDAL.Get(id);

            return ContractorLegalEmployeeMapper.MapToViewModel(contractorLegalEmployee);
        }

        public async Task<int> UpdateOrCreate(ContractorLegalEmployeeViewModel contractorLegalEmployeeViewModel)
        {
            var contractorLegalEmployee = ContractorLegalEmployeeMapper.MapToModel(contractorLegalEmployeeViewModel);

            return contractorLegalEmployee.Id == 0 
                ? await contractorLegalEmployeeDAL.Create(contractorLegalEmployee) 
                : await contractorLegalEmployeeDAL.Update(contractorLegalEmployee);
        }

        public async Task<ICollection<ContractorLegalEmployeeViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var contractorLegalEmployees = await contractorLegalEmployeeDAL.Find(searchStr);

            return ConvertContractorLegalEmployeesCollection(contractorLegalEmployees);
        }

        public async Task<ICollection<ContractorLegalEmployeeViewModel>> FindAll()
        {
            var contractorLegalEmployees = await contractorLegalEmployeeDAL.GetAll();
            return ConvertContractorLegalEmployeesCollection(contractorLegalEmployees);
        }

        public async Task<int> Delete(int id)
        {
            return await contractorLegalEmployeeDAL.Delete(id);
        }

        private ICollection<ContractorLegalEmployeeViewModel> ConvertContractorLegalEmployeesCollection(ICollection<ContractorLegalEmployee> contractorLegalEmployees)
        {
            var contractorLegalEmployeesVM = new List<ContractorLegalEmployeeViewModel>(contractorLegalEmployees.Count);

            foreach (var contractorLegalEmployee in contractorLegalEmployees)
                contractorLegalEmployeesVM.Add(ContractorLegalEmployeeMapper.MapToViewModel(contractorLegalEmployee));

            return contractorLegalEmployeesVM;
        }
    }
}
