using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.BLL;

namespace EffectCert.BLL.Contractors
{
    public class ContractorLegalBLL : ICommonBLL<ContractorLegal>
    {
        private readonly ContractorLegalRepo contractorLegalDAL;

        public ContractorLegalBLL(ContractorLegalRepo contractorLegalDAL)
        {
            this.contractorLegalDAL = contractorLegalDAL;
        }

        public async Task<ContractorLegal> Get(int id)
        {
            return await contractorLegalDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(ContractorLegal contractorLegal)
        {
            return contractorLegal.Id == 0 
                ? await contractorLegalDAL.Create(contractorLegal) 
                : await contractorLegalDAL.Update(contractorLegal);
        }

        public async Task<IEnumerable<ContractorLegal>> Find(string searchStr)
        {
            return await contractorLegalDAL.Find(searchStr);
        }
    }
}
