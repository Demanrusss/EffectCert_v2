using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewMappers.Contractors
{
    public static class ContractorLegalMapper
    {
        public static ContractorLegal MapToModel(ContractorLegalViewModel contractorLegalViewModel)
        {
            return new ContractorLegal()
            {
                Id = contractorLegalViewModel.Id,
                BankAccount = contractorLegalViewModel.BankAccount != null 
                    ? BankAccountMapper.MapToModel(contractorLegalViewModel.BankAccount!)
                    : null,
                BIN = contractorLegalViewModel.BIN,
                Employees = ConvertToModelCollection(contractorLegalViewModel.Employees),
                FactAddress = AddressMapper.MapToModel(contractorLegalViewModel.FactAddress ?? contractorLegalViewModel.RegAddress),
                FullName = contractorLegalViewModel.FullName,
                RegAddress = AddressMapper.MapToModel(contractorLegalViewModel.RegAddress),
                ShortName = contractorLegalViewModel.ShortName
            };
        }

        public static ContractorLegalViewModel MapToViewModel(ContractorLegal contractorLegal)
        {
            if (contractorLegal == null)
                return new ContractorLegalViewModel();

            return new ContractorLegalViewModel()
            {
                Id = contractorLegal.Id,
                BankAccount = contractorLegal.BankAccount != null 
                    ? BankAccountMapper.MapToViewModel(contractorLegal.BankAccount!)
                    : null,
                BIN = contractorLegal.BIN,
                Employees = ConvertToViewModelCollection(contractorLegal.Employees),
                FactAddress = AddressMapper.MapToViewModel(contractorLegal.FactAddress),
                FullName = contractorLegal.FullName,
                RegAddress = AddressMapper.MapToViewModel(contractorLegal.RegAddress),
                ShortName = contractorLegal.ShortName,
                IsAddressSame = contractorLegal.RegAddress == contractorLegal.FactAddress
            };
        }

        private static ICollection<ContractorLegalEmployeeViewModel> ConvertToViewModelCollection(ICollection<ContractorLegalEmployee> contractorLegalEmployees)
        {
            var contractorLegalEmployeesVM = new List<ContractorLegalEmployeeViewModel>(contractorLegalEmployees.Count);

            foreach (var contractorLegalEmployee in contractorLegalEmployees)
                contractorLegalEmployeesVM.Add(ContractorLegalEmployeeMapper.MapToViewModel(contractorLegalEmployee));

            return contractorLegalEmployeesVM;
        }

        private static ICollection<ContractorLegalEmployee> ConvertToModelCollection(ICollection<ContractorLegalEmployeeViewModel> contractorLegalEmployeesVM)
        {
            var contractorLegalEmployees = new List<ContractorLegalEmployee>(contractorLegalEmployeesVM.Count);

            foreach (var assessBodyEmployeeVM in contractorLegalEmployeesVM)
                contractorLegalEmployees.Add(ContractorLegalEmployeeMapper.MapToModel(assessBodyEmployeeVM));

            return contractorLegalEmployees;
        }
    }
}
