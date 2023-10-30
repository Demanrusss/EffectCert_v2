using EffectCert.DAL.Entities.Contractors;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.ViewMappers.Contractors
{
    public static class AssessBodyMapper
    {
        public static AssessBody MapToModel(AssessBodyViewModel assessBodyViewModel)
        {
            return new AssessBody()
            {
                Id = assessBodyViewModel.Id,
                Address = AddressMapper.MapToModel(assessBodyViewModel.Address),
                AssessBodyEmployees = ConvertToModelCollection(assessBodyViewModel.AssessBodyEmployees),
                Attestate = AttestateMapper.MapToModel(assessBodyViewModel.Attestate),
                ContractorLegal = ContractorLegalMapper.MapToModel(assessBodyViewModel.ContractorLegal),
                Name = assessBodyViewModel.Name,
                ShortName = assessBodyViewModel.ShortName
            };
        }

        public static AssessBodyViewModel MapToViewModel(AssessBody assessBody)
        {
            return new AssessBodyViewModel()
            {
                Id = assessBody.Id,
                Address = AddressMapper.MapToViewModel(assessBody.Address),
                AssessBodyEmployees = ConvertToViewModelCollection(assessBody.AssessBodyEmployees),
                Attestate = AttestateMapper.MapToViewModel(assessBody.Attestate),
                ContractorLegal = ContractorLegalMapper.MapToViewModel(assessBody.ContractorLegal),
                Name = assessBody.Name,
                ShortName = assessBody.ShortName
            };
        }

        private static ICollection<AssessBodyEmployeeViewModel> ConvertToViewModelCollection(ICollection<AssessBodyEmployee> assessBodyEmployees)
        {
            var assessBodyEmployeesVM = new List<AssessBodyEmployeeViewModel>(assessBodyEmployees.Count);

            foreach (var assessBodyEmployee in assessBodyEmployees)
                assessBodyEmployeesVM.Add(AssessBodyEmployeeMapper.MapToViewModel(assessBodyEmployee));

            return assessBodyEmployeesVM;
        }

        private static ICollection<AssessBodyEmployee> ConvertToModelCollection(ICollection<AssessBodyEmployeeViewModel> assessBodyEmployeesVM)
        {
            var assessBodyEmployees = new List<AssessBodyEmployee>(assessBodyEmployeesVM.Count);

            foreach (var assessBodyEmployeeVM in assessBodyEmployeesVM)
                assessBodyEmployees.Add(AssessBodyEmployeeMapper.MapToModel(assessBodyEmployeeVM));

            return assessBodyEmployees;
        }
    }
}
