using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewMappers.Documents;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.ViewMappers.Contractors
{
    public static class LaboratoryMapper
    {
        public static Laboratory MapToModel(LaboratoryViewModel viewModel)
        {
            return new Laboratory()
            {
                Id = viewModel.Id,
                LaboratoryEmployees = ConvertCollection(viewModel.LaboratoryEmployees),
                AttestateId = viewModel.AttestateId,
                ContractorLegalId = viewModel.ContractorLegalId,
                Name = viewModel.Name,
                ShortName = viewModel.ShortName
            };
        }

        public static LaboratoryViewModel MapToViewModel(Laboratory model)
        {
            if (model == null)
                return new LaboratoryViewModel();

            return new LaboratoryViewModel()
            {
                Id = model.Id,
                LaboratoryEmployees = ConvertCollection(model.LaboratoryEmployees),
                Attestate = AttestateMapper.MapToViewModel(model.Attestate ?? new Attestate()),
                ContractorLegal = ContractorLegalMapper.MapToViewModel(model.ContractorLegal),
                Name = model.Name,
                ShortName = model.ShortName
            };
        }

        private static ICollection<LaboratoryEmployeeViewModel> ConvertCollection(ICollection<LaboratoryEmployee> sourceCollection)
        {
            var targetCollection = new List<LaboratoryEmployeeViewModel>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(LaboratoryEmployeeMapper.MapToViewModel(element));

            return targetCollection;
        }

        private static ICollection<LaboratoryEmployee> ConvertCollection(ICollection<LaboratoryEmployeeViewModel> sourceCollection)
        {
            var targetCollection = new List<LaboratoryEmployee>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(LaboratoryEmployeeMapper.MapToModel(element));

            return targetCollection;
        }
    }
}
