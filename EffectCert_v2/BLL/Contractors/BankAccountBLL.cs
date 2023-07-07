using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.BLL;

namespace EffectCert.BLL.Contractors
{
    public class BankAccountBLL : ICommonBLL<BankAccount>
    {
        private readonly BankAccountRepo bankAccountDAL;

        public BankAccountBLL(BankAccountRepo bankAccountDAL)
        {
            this.bankAccountDAL = bankAccountDAL;
        }

        public async Task<BankAccount> Get(int id)
        {
            return await bankAccountDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(BankAccount bankAccount)
        {
            return bankAccount.Id == 0 
                ? await bankAccountDAL.Create(bankAccount) 
                : await bankAccountDAL.Update(bankAccount);
        }

        public async Task<IEnumerable<BankAccount>> Find(string searchStr)
        {
            return await bankAccountDAL.Find(searchStr);
        }
    }
}
