using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewMappers.Contractors
{
    public static class ContractorLegalEmployeeMapper
    {
        public static ContractorLegalEmployee MapToModel(ContractorLegalEmployeeViewModel contractorLegalEmployeeViewModel)
        {
            return new ContractorLegalEmployee()
            {
                Id = contractorLegalEmployeeViewModel.Id,
                ContractorIndividual = ContractorIndividualMapper.MapToModel(contractorLegalEmployeeViewModel.ContractorIndividual),
                ContractorLegal = ContractorLegalMapper.MapToModel(contractorLegalEmployeeViewModel.ContractorLegal),
                IsManager = contractorLegalEmployeeViewModel.IsManager,
                Position = contractorLegalEmployeeViewModel.Position
            };
        }

        public static ContractorLegalEmployeeViewModel MapToViewModel(ContractorLegalEmployee contractorLegalEmployee)
        {
            if (contractorLegalEmployee == null)
                return new ContractorLegalEmployeeViewModel();

            return new ContractorLegalEmployeeViewModel()
            {
                Id = contractorLegalEmployee.Id,
                ContractorIndividual = ContractorIndividualMapper.MapToViewModel(contractorLegalEmployee.ContractorIndividual),
                ContractorLegal = ContractorLegalMapper.MapToViewModel(contractorLegalEmployee.ContractorLegal),
                IsManager = contractorLegalEmployee.IsManager,
                Position = contractorLegalEmployee.Position
            };
        }
    }
}
