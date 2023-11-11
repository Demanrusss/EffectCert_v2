using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.ViewMappers.Documents;
using EffectCert.ViewModels.Documents;

namespace EffectCert.BLL.Documents
{
    public class ContractBLL : ICommonBLL<ContractViewModel>
    {
        private readonly ContractRepo contractDAL;

        public ContractBLL(ContractRepo contractDAL)
        {
            this.contractDAL = contractDAL;
        }

        public async Task<ContractViewModel> Get(int id)
        {
            var contract = await contractDAL.Get(id);

            return ContractMapper.MapToViewModel(contract);
        }

        public async Task<int> UpdateOrCreate(ContractViewModel contractVM)
        {
            var contract = ContractMapper.MapToModel(contractVM);

            return contract.Id == 0 
                ? await contractDAL.Create(contract) 
                : await contractDAL.Update(contract);
        }

        public async Task<ICollection<ContractViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var contracts = await contractDAL.Find(searchStr);

            return ConvertCollection(contracts);
        }

        public async Task<ICollection<ContractViewModel>> FindAll()
        {
            var contracts = await contractDAL.GetAll();

            return ConvertCollection(contracts);
        }

        public async Task<int> Delete(int id)
        {
            return await contractDAL.Delete(id);
        }

        private ICollection<ContractViewModel> ConvertCollection(ICollection<Contract> collection)
        {
            var collectionVM = new List<ContractViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(ContractMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
