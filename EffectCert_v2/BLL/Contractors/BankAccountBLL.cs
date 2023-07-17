﻿using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.BLL;
using Microsoft.IdentityModel.Tokens;

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
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await bankAccountDAL.Find(searchStr);
        }

        public async Task<IEnumerable<BankAccount>> FindAll()
        {
            return await bankAccountDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await bankAccountDAL.Delete(id);
        }
    }
}
