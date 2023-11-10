using EffectCert.DAL.Entities.Contractors;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.ViewMappers.Contractors
{
    public static class AssessBodyEmployeeMapper
    {
        public static AssessBodyEmployee MapToModel(AssessBodyEmployeeViewModel assessBodyEmployeeViewModel)
        {
            return new AssessBodyEmployee()
            {
                Id = assessBodyEmployeeViewModel.Id,
                ContractorLegalEmployeeId = assessBodyEmployeeViewModel.ContractorLegalEmployeeId,
                ExpertAuditorOrientation = assessBodyEmployeeViewModel.ExpertAuditorOrientation,
                Position = assessBodyEmployeeViewModel.Position
            };
        }

        public static AssessBodyEmployeeViewModel MapToViewModel(AssessBodyEmployee assessBodyEmployee)
        {
            if (assessBodyEmployee == null)
                return new AssessBodyEmployeeViewModel();

            return new AssessBodyEmployeeViewModel()
            {
                Id = assessBodyEmployee.Id,
                ContractorLegalEmployeeId = assessBodyEmployee.ContractorLegalEmployeeId,
                ContractorLegalEmployee = ContractorLegalEmployeeMapper.MapToViewModel(assessBodyEmployee.ContractorLegalEmployee),
                ExpertAuditorOrientation = assessBodyEmployee.ExpertAuditorOrientation,
                Position = assessBodyEmployee.Position
            };
        }
    }
}
