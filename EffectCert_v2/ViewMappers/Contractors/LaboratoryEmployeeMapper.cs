using EffectCert.DAL.Entities.Contractors;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.ViewMappers.Contractors
{
    public static class LaboratoryEmployeeMapper
    {
        public static LaboratoryEmployee MapToModel(LaboratoryEmployeeViewModel viewModel)
        {
            return new LaboratoryEmployee()
            {
                Id = viewModel.Id,
                ContractorLegalEmployeeId = viewModel.ContractorLegalEmployeeId,
                Position = viewModel.Position
            };
        }

        public static LaboratoryEmployeeViewModel MapToViewModel(LaboratoryEmployee model)
        {
            if (model == null)
                return new LaboratoryEmployeeViewModel();

            return new LaboratoryEmployeeViewModel()
            {
                Id = model.Id,
                ContractorLegalEmployeeId = model.ContractorLegalEmployeeId,
                ContractorLegalEmployee = ContractorLegalEmployeeMapper.MapToViewModel(model.ContractorLegalEmployee),
                Position = model.Position
            };
        }
    }
}
