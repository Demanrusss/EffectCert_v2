using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using Microsoft.IdentityModel.Tokens;

namespace EffectCert.BLL.Documents
{
    public class ContractBLL : ICommonBLL<Contract>
    {
        private readonly ContractRepo contractDAL;

        public ContractBLL(ContractRepo contractDAL)
        {
            this.contractDAL = contractDAL;
        }

        public async Task<Contract> Get(int id)
        {
            return await contractDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(Contract contract)
        {
            return contract.Id == 0 
                ? await contractDAL.Create(contract) 
                : await contractDAL.Update(contract);
        }

        public async Task<IEnumerable<Contract>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await contractDAL.Find(searchStr);
        }

        public async Task<IEnumerable<Contract>> FindAll()
        {
            return await contractDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await contractDAL.Delete(id);
        }
    }
}
