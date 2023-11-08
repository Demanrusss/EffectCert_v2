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
                ContractorLegalEmployeeFullName = String.Format("{0} {1}", assessBodyEmployee.ContractorLegalEmployee.ContractorIndividual.LastName
                + assessBodyEmployee.ContractorLegalEmployee.ContractorIndividual.FirstName),
                ExpertAuditorOrientation = assessBodyEmployee.ExpertAuditorOrientation,
                Position = assessBodyEmployee.Position
            };
        }
    }
}
