using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewMappers.Contractors;
using EffectCert.BLL.Interfaces;

namespace EffectCert.BLL.Contractors
{
    public class BankAccountBLL : IBankAccountBLL
    {
        private readonly BankAccountRepo bankAccountDAL;

        public BankAccountBLL(BankAccountRepo bankAccountDAL)
        {
            this.bankAccountDAL = bankAccountDAL;
        }

        public async Task<BankAccountViewModel> Get(int id)
        {
            var bankAccount = await bankAccountDAL.Get(id);
            return BankAccountMapper.MapToViewModel(bankAccount);
        }

        public async Task<int> UpdateOrCreate(BankAccountViewModel bankAccountVM)
        {
            var bankAccount = BankAccountMapper.MapToModel(bankAccountVM);

            return bankAccount.Id == 0 
                ? await bankAccountDAL.Create(bankAccount) 
                : await bankAccountDAL.Update(bankAccount);
        }

        public async Task<ICollection<BankAccountViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var bankAccounts = await bankAccountDAL.Find(searchStr);

            return ConvertCollection(bankAccounts);
        }

        public async Task<ICollection<BankAccountViewModel>> FindAll()
        {
            var bankAccounts = await bankAccountDAL.GetAll();

            return ConvertCollection(bankAccounts);
        }

        public async Task<int> Delete(int id)
        {
            return await bankAccountDAL.Delete(id);
        }

        private ICollection<BankAccountViewModel> ConvertCollection(ICollection<BankAccount> collection)
        {
            var collectionVM = new List<BankAccountViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(BankAccountMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
