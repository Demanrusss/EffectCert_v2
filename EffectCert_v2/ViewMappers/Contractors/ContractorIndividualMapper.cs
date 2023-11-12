using EffectCert.DAL.Entities.Contractors;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.ViewMappers.Contractors
{
    public static class ContractorIndividualMapper
    {
        public static ContractorIndividual MapToModel(ContractorIndividualViewModel viewModel)
        {
            return new ContractorIndividual()
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                IIN = viewModel.IIN,
                LastName = viewModel.LastName,
                MiddleName = viewModel.MiddleName
            };
        }

        public static ContractorIndividualViewModel MapToViewModel(ContractorIndividual model)
        {
            if (model == null)
                return new ContractorIndividualViewModel();

            return new ContractorIndividualViewModel()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                IIN = model.IIN,
                LastName = model.LastName,
                MiddleName = model.MiddleName
            };
        }
    }
}
