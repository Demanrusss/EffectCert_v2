using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewMappers.Contractors;
using EffectCert.BLL.Interfaces;

namespace EffectCert.BLL.Contractors
{
    public class ContractorLegalBLL : IContractorLegalBLL
    {
        private readonly ContractorLegalRepo contractorLegalDAL;

        public ContractorLegalBLL(ContractorLegalRepo contractorLegalDAL)
        {
            this.contractorLegalDAL = contractorLegalDAL;
        }

        public async Task<ContractorLegalViewModel> Get(int id)
        {
            var contractorLegal = await contractorLegalDAL.Get(id);

            return ContractorLegalMapper.MapToViewModel(contractorLegal);
        }

        public async Task<int> UpdateOrCreate(ContractorLegalViewModel contractorLegalVM)
        {
            if (contractorLegalVM.EmployeesIds != null)
                foreach (var employee in contractorLegalVM.EmployeesIds)
                    contractorLegalVM.Employees.Add(new ContractorLegalEmployeeViewModel() { Id = employee });

            var contractorLegal = ContractorLegalMapper.MapToModel(contractorLegalVM);

            return contractorLegal.Id == 0 
                ? await contractorLegalDAL.Create(contractorLegal) 
                : await contractorLegalDAL.Update(contractorLegal);
        }

        public async Task<ICollection<ContractorLegalViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrEmpty(searchStr))
                return await FindAll();

            var contractorLegals = await contractorLegalDAL.Find(searchStr);

            return ConvertCollection(contractorLegals);
        }

        public async Task<ICollection<ContractorLegalViewModel>> FindAll()
        {
            var contractorLegals = await contractorLegalDAL.GetAll();
            return ConvertCollection(contractorLegals);
        }

        public async Task<int> Delete(int id)
        {
            return await contractorLegalDAL.Delete(id);
        }

        private ICollection<ContractorLegalViewModel> ConvertCollection(ICollection<ContractorLegal> collection)
        {
            var collectionVM = new List<ContractorLegalViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(ContractorLegalMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
