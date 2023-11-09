using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.BLL;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewMappers.Contractors;

namespace EffectCert.BLL.Contractors
{
    public class ContractorLegalBLL : ICommonBLL<ContractorLegalViewModel>
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

        public async Task<int> UpdateOrCreate(ContractorLegalViewModel contractorLegalViewModel)
        {
            var contractorLegal = ContractorLegalMapper.MapToModel(contractorLegalViewModel);

            return contractorLegal.Id == 0 
                ? await contractorLegalDAL.Create(contractorLegal) 
                : await contractorLegalDAL.Update(contractorLegal);
        }

        public async Task<ICollection<ContractorLegalViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrEmpty(searchStr))
                return await FindAll();

            var contractorLegals = await contractorLegalDAL.Find(searchStr);

            return ConvertAssessBodyCollection(contractorLegals);
        }

        public async Task<ICollection<ContractorLegalViewModel>> FindAll()
        {
            var contractorLegals = await contractorLegalDAL.GetAll();
            return ConvertAssessBodyCollection(contractorLegals);
        }

        public async Task<int> Delete(int id)
        {
            return await contractorLegalDAL.Delete(id);
        }

        private ICollection<ContractorLegalViewModel> ConvertAssessBodyCollection(ICollection<ContractorLegal> contractorLegals)
        {
            var contractorLegalsVM = new List<ContractorLegalViewModel>(contractorLegals.Count);

            foreach (var contractorLegal in contractorLegals)
                contractorLegalsVM.Add(ContractorLegalMapper.MapToViewModel(contractorLegal));

            return contractorLegalsVM;
        }
    }
}
