using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Contractors
{
    public class BankAccountRepo : IRepository<BankAccount>
    {
        private readonly AppDBContext appDBContext;

        public BankAccountRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<BankAccount>> GetAll()
        {
            return await appDBContext.BankAccounts.ToListAsync();
        }

        public async Task<BankAccount> Get(int id)
        {
            return await appDBContext.BankAccounts.FirstOrDefaultAsync(a => a.Id == id) ?? new BankAccount();
        }

        public async Task<ICollection<BankAccount>> Find(string searchStr = "")
        {
            var result = appDBContext.BankAccounts.Where(c => c.IIK.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(BankAccount bankAccount)
        {
            if (bankAccount == null)
                throw new ArgumentNullException();

            appDBContext.BankAccounts.Add(bankAccount);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(BankAccount bankAccount)
        {
            if (bankAccount == null)
                return 0;

            appDBContext.BankAccounts.Update(bankAccount);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            BankAccount? bankAccount = await appDBContext.BankAccounts.FindAsync(id);
            if (bankAccount == null)
                return 0;

            appDBContext.BankAccounts.Remove(bankAccount);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
