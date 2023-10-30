using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewMappers.Contractors
{
    public static class ContractorIndividualMapper
    {
        public static ContractorIndividual MapToModel(ContractorIndividualViewModel contractorIndividualViewModel)
        {
            return new ContractorIndividual()
            {
                Id = contractorIndividualViewModel.Id,
                FirstName = contractorIndividualViewModel.FirstName,
                IIN = contractorIndividualViewModel.IIN,
                LastName = contractorIndividualViewModel.LastName,
                MiddleName = contractorIndividualViewModel.MiddleName
            };
        }

        public static ContractorIndividualViewModel MapToViewModel(ContractorIndividual contractorIndividual)
        {
            return new ContractorIndividualViewModel()
            {
                Id = contractorIndividual.Id,
                FirstName = contractorIndividual.FirstName,
                IIN = contractorIndividual.IIN,
                LastName = contractorIndividual.LastName,
                MiddleName = contractorIndividual.MiddleName
            };
        }
    }
}
