using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.BLL;

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

        public async Task<IEnumerable<ContractorIndividual>> Find(string searchStr)
        {
            return await contractorIndividualDAL.Find(searchStr);
        }
    }
}
