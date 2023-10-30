using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewMappers.Contractors
{
    public static class BankAccountMapper
    {
        public static BankAccount MapToModel(BankAccountViewModel bankAccountViewModel)
        {
            return new BankAccount()
            {
                Id = bankAccountViewModel.Id,
                BankName = bankAccountViewModel.BankName,
                BIK = bankAccountViewModel.BIK,
                IIK = bankAccountViewModel.IIK
            };
        }

        public static BankAccountViewModel MapToViewModel(BankAccount bankAccount)
        {
            return new BankAccountViewModel()
            {
                Id = bankAccount.Id,
                BankName = bankAccount.BankName,
                BIK = bankAccount.BIK,
                IIK = bankAccount.IIK
            };
        }
    }
}
