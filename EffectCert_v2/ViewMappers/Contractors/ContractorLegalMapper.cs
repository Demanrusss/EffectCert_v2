using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewMappers.Contractors
{
    public static class ContractorLegalMapper
    {
        public static ContractorLegal MapToModel(ContractorLegalViewModel viewModel)
        {
            return new ContractorLegal()
            {
                Id = viewModel.Id,
                BankAccount = BankAccountMapper.MapToModel(viewModel.BankAccount ?? new BankAccountViewModel()),
                BIN = viewModel.BIN,
                Employees = ConvertCollection(viewModel.Employees),
                FactAddress = AddressMapper.MapToModel(viewModel.FactAddress ?? viewModel.RegAddress),
                FullName = viewModel.FullName,
                RegAddress = AddressMapper.MapToModel(viewModel.RegAddress),
                ShortName = viewModel.ShortName
            };
        }

        public static ContractorLegalViewModel MapToViewModel(ContractorLegal model)
        {
            if (model == null)
                return new ContractorLegalViewModel();

            return new ContractorLegalViewModel()
            {
                Id = model.Id,
                BankAccount = BankAccountMapper.MapToViewModel(model.BankAccount ?? new BankAccount()),
                BIN = model.BIN,
                Employees = ConvertCollection(model.Employees),
                FactAddress = AddressMapper.MapToViewModel(model.FactAddress),
                FullName = model.FullName,
                RegAddress = AddressMapper.MapToViewModel(model.RegAddress),
                ShortName = model.ShortName,
                IsAddressSame = model.RegAddress == model.FactAddress
            };
        }

        private static ICollection<ContractorLegalEmployeeViewModel> ConvertCollection(ICollection<ContractorLegalEmployee> sourceCollection)
        {
            var targetCollection = new List<ContractorLegalEmployeeViewModel>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(ContractorLegalEmployeeMapper.MapToViewModel(element));

            return targetCollection;
        }

        private static ICollection<ContractorLegalEmployee> ConvertCollection(ICollection<ContractorLegalEmployeeViewModel> sourceCollection)
        {
            var targetCollection = new List<ContractorLegalEmployee>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(ContractorLegalEmployeeMapper.MapToModel(element));

            return targetCollection;
        }
    }
}
