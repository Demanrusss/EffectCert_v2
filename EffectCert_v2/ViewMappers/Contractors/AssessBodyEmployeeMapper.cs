using EffectCert.DAL.Entities.Contractors;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.ViewMappers.Contractors
{
    public static class AssessBodyEmployeeMapper
    {
        public static AssessBodyEmployee MapToModel(AssessBodyEmployeeViewModel viewModel)
        {
            return new AssessBodyEmployee()
            {
                Id = viewModel.Id,
                ContractorLegalEmployeeId = viewModel.ContractorLegalEmployeeId,
                ExpertAuditorOrientation = viewModel.ExpertAuditorOrientation,
                Position = viewModel.Position
            };
        }

        public static AssessBodyEmployeeViewModel MapToViewModel(AssessBodyEmployee model)
        {
            if (model == null)
                return new AssessBodyEmployeeViewModel();

            return new AssessBodyEmployeeViewModel()
            {
                Id = model.Id,
                ContractorLegalEmployeeId = model.ContractorLegalEmployeeId,
                ContractorLegalEmployee = ContractorLegalEmployeeMapper.MapToViewModel(model.ContractorLegalEmployee),
                ExpertAuditorOrientation = model.ExpertAuditorOrientation,
                Position = model.Position
            };
        }
    }
}
