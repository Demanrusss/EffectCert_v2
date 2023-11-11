using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewMappers.Contractors
{
    public static class ContractorLegalEmployeeMapper
    {
        public static ContractorLegalEmployee MapToModel(ContractorLegalEmployeeViewModel viewModel)
        {
            return new ContractorLegalEmployee()
            {
                Id = viewModel.Id,
                ContractorIndividual = ContractorIndividualMapper.MapToModel(viewModel.ContractorIndividual),
                ContractorLegal = ContractorLegalMapper.MapToModel(viewModel.ContractorLegal),
                IsManager = viewModel.IsManager,
                Position = viewModel.Position
            };
        }

        public static ContractorLegalEmployeeViewModel MapToViewModel(ContractorLegalEmployee model)
        {
            if (model == null)
                return new ContractorLegalEmployeeViewModel();

            return new ContractorLegalEmployeeViewModel()
            {
                Id = model.Id,
                ContractorIndividual = ContractorIndividualMapper.MapToViewModel(model.ContractorIndividual),
                ContractorLegal = ContractorLegalMapper.MapToViewModel(model.ContractorLegal),
                IsManager = model.IsManager,
                Position = model.Position
            };
        }
    }
}
