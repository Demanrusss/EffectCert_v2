﻿using EffectCert.DAL.Entities.Contractors;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.ViewMappers.Contractors
{
    public static class ContractorLegalEmployeeMapper
    {
        public static ContractorLegalEmployee MapToModel(ContractorLegalEmployeeViewModel viewModel)
        {
            return new ContractorLegalEmployee()
            {
                Id = viewModel.Id ?? 0,
                ContractorIndividualId = viewModel.ContractorIndividualId,
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
                IsManager = model.IsManager,
                Position = model.Position
            };
        }
    }
}
