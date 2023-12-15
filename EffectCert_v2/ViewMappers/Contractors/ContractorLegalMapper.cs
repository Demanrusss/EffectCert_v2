using EffectCert.DAL.Entities.Contractors;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.ViewMappers.Contractors
{
    public static class ContractorLegalMapper
    {
        public static ContractorLegal MapToModel(ContractorLegalViewModel viewModel)
        {
            if (viewModel.IsAddressSame)
                viewModel.FactAddressId = viewModel.RegAddressId;

            return new ContractorLegal()
            {
                Id = viewModel.Id,
                BankAccountId = viewModel.BankAccountId,
                BIN = viewModel.BIN,
                Employees = ConvertCollection(viewModel.Employees),
                FactAddressId = viewModel.FactAddressId,
                Name = viewModel.Name,
                RegAddressId = viewModel.RegAddressId,
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
                Name = model.Name,
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
