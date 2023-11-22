using EffectCert.DAL.Entities.Contractors;
using EffectCert.ViewMappers.Documents;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.ViewMappers.Contractors
{
    public class AssessBodyMapper
    {
        public static AssessBody MapToModel(AssessBodyViewModel viewModel)
        {
            return new AssessBody()
            {
                Id = viewModel.Id,
                AddressId = viewModel.AddressId,
                Employees = ConvertCollection(viewModel.AssessBodyEmployees),
                AttestateId = viewModel.AttestateId,
                ContractorLegalId = viewModel.ContractorLegalId,
                Name = viewModel.Name,
                ShortName = viewModel.ShortName
            };
        }

        public static AssessBodyViewModel MapToViewModel(AssessBody model)
        {
            if (model == null)
                return new AssessBodyViewModel();

            return new AssessBodyViewModel()
            {
                Id = model.Id,
                Address = AddressMapper.MapToViewModel(model.Address),
                AssessBodyEmployees = ConvertCollection(model.Employees),
                Attestate = AttestateMapper.MapToViewModel(model.Attestate),
                ContractorLegal = ContractorLegalMapper.MapToViewModel(model.ContractorLegal),
                Name = model.Name,
                ShortName = model.ShortName
            };
        }

        private static ICollection<AssessBodyEmployeeViewModel> ConvertCollection(ICollection<AssessBodyEmployee> sourceCollection)
        {
            var targetCollection = new List<AssessBodyEmployeeViewModel>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(AssessBodyEmployeeMapper.MapToViewModel(element));

            return targetCollection;
        }

        private static ICollection<AssessBodyEmployee> ConvertCollection(ICollection<AssessBodyEmployeeViewModel> sourceCollection)
        {
            var targetCollection = new List<AssessBodyEmployee>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(AssessBodyEmployeeMapper.MapToModel(element));

            return targetCollection;
        }
    }
}
