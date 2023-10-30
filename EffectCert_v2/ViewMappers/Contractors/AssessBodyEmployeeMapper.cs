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
                ContractorLegalEmployee = ContractorLegalEmployeeMapper.MapToModel(assessBodyEmployeeViewModel.ContractorLegalEmployee),
                ExpertAuditorOrientation = assessBodyEmployeeViewModel.ExpertAuditorOrientation,
                Position = assessBodyEmployeeViewModel.Position
            };
        }

        public static AssessBodyEmployeeViewModel MapToViewModel(AssessBodyEmployee assessBodyEmployee)
        {
            return new AssessBodyEmployeeViewModel()
            {
                Id = assessBodyEmployee.Id,
                ContractorLegalEmployee = ContractorLegalEmployeeMapper.MapToViewModel(assessBodyEmployee.ContractorLegalEmployee),
                ExpertAuditorOrientation = assessBodyEmployee.ExpertAuditorOrientation,
                Position = assessBodyEmployee.Position
            };
        }
    }
}
