using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewMappers.Contractors;

namespace EffectCert.BLL.Contractors
{
    public class ContractorIndividualBLL : ICommonBLL<ContractorIndividualViewModel>
    {
        private readonly ContractorIndividualRepo contractorIndividualDAL;

        public ContractorIndividualBLL(ContractorIndividualRepo contractorIndividualDAL)
        {
            this.contractorIndividualDAL = contractorIndividualDAL;
        }

        public async Task<ContractorIndividualViewModel> Get(int id)
        {
            var contractorIndividual = await contractorIndividualDAL.Get(id);

            return ContractorIndividualMapper.MapToViewModel(contractorIndividual);
        }

        public async Task<int> UpdateOrCreate(ContractorIndividualViewModel contractorIndividualVM)
        {
            var contractorIndividual = ContractorIndividualMapper.MapToModel(contractorIndividualVM);

            return contractorIndividual.Id == 0 
                ? await contractorIndividualDAL.Create(contractorIndividual) 
                : await contractorIndividualDAL.Update(contractorIndividual);
        }

        public async Task<ICollection<ContractorIndividualViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var contractorIndividuals = await contractorIndividualDAL.Find(searchStr);

            return ConvertCollection(contractorIndividuals);
        }

        public async Task<ICollection<ContractorIndividualViewModel>> FindAll()
        {
            var contractorIndividuals = await contractorIndividualDAL.GetAll();

            return ConvertCollection(contractorIndividuals);
        }

        public async Task<int> Delete(int id)
        {
            return await contractorIndividualDAL.Delete(id);
        }

        private ICollection<ContractorIndividualViewModel> ConvertCollection(ICollection<ContractorIndividual> collection)
        {
            var collectionVM = new List<ContractorIndividualViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(ContractorIndividualMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
