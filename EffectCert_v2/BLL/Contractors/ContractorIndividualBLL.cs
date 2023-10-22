using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.BLL;
using Microsoft.IdentityModel.Tokens;

namespace EffectCert.BLL.Contractors
{
    public class ContractorIndividualBLL : ICommonBLL<ContractorIndividual>
    {
        private readonly ContractorIndividualRepo contractorIndividualDAL;

        public ContractorIndividualBLL(ContractorIndividualRepo contractorIndividualDAL)
        {
            this.contractorIndividualDAL = contractorIndividualDAL;
        }

        public async Task<ContractorIndividual> Get(int id)
        {
            return await contractorIndividualDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(ContractorIndividual contractorIndividual)
        {
            return contractorIndividual.Id == 0 
                ? await contractorIndividualDAL.Create(contractorIndividual) 
                : await contractorIndividualDAL.Update(contractorIndividual);
        }

        public async Task<ICollection<ContractorIndividual>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await contractorIndividualDAL.Find(searchStr);
        }

        public async Task<ICollection<ContractorIndividual>> FindAll()
        {
            return await contractorIndividualDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await contractorIndividualDAL.Delete(id);
        }
    }
}
