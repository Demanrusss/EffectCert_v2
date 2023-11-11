using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewMappers.Contractors
{
    public static class BankAccountMapper
    {
        public static BankAccount MapToModel(BankAccountViewModel viewModel)
        {
            return new BankAccount()
            {
                Id = viewModel.Id,
                BankName = viewModel.BankName,
                BIK = viewModel.BIK,
                IIK = viewModel.IIK
            };
        }

        public static BankAccountViewModel MapToViewModel(BankAccount model)
        {
            if (model == null)
                return new BankAccountViewModel();

            return new BankAccountViewModel()
            {
                Id = model.Id,
                BankName = model.BankName,
                BIK = model.BIK,
                IIK = model.IIK
            };
        }
    }
}
