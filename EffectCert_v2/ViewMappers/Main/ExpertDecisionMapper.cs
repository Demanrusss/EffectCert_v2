using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Entities.Main;
using EffectCert.ViewMappers.Contractors;
using EffectCert.ViewMappers.Documents;
using EffectCert.ViewModels.Documents;
using EffectCert.ViewModels.Main;

namespace EffectCert.ViewMappers.Main
{
    public static class ExpertDecisionMapper
    {
        public static ExpertDecision MapToModel(ExpertDecisionViewModel viewModel)
        {
            return new ExpertDecision()
            {
                Id = viewModel.Id,
                Date = viewModel.Date,
                Number = viewModel.Number,
                ApplicationId = viewModel.ApplicationId,
                DocsAnalizeExpertId = viewModel.DocsAnalizeExpertId,
                DocsAnalizeExpertSignDate = viewModel.DocsAnalizeExpertSignDate,
                ConformityMarkInfo = viewModel.ConformityMarkInfo,
                ExpertId = viewModel.ExpertId,
                TestProtocols = ConvertCollection(viewModel.TestProtocols),
                ValidDate = viewModel.ValidDate
            };
        }

        public static ExpertDecisionViewModel MapToViewModel(ExpertDecision model)
        {
            if (model == null)
                return new ExpertDecisionViewModel();

            return new ExpertDecisionViewModel()
            {
                Id = model.Id,
                Date = model.Date,
                Number = model.Number,
                Application = ApplicationMapper.MapToViewModel(model.Application),
                DocsAnalizeExpert = AssessBodyEmployeeMapper.MapToViewModel(model.DocsAnalizeExpert ?? new AssessBodyEmployee()),
                DocsAnalizeExpertSignDate = model.DocsAnalizeExpertSignDate,
                ConformityMarkInfo = model.ConformityMarkInfo,
                Expert = AssessBodyEmployeeMapper.MapToViewModel(model.Expert),
                TestProtocols = ConvertCollection(model.TestProtocols),
                ValidDate = model.ValidDate
            };
        }

        private static ICollection<TestProtocolViewModel> ConvertCollection(ICollection<TestProtocol> sourceCollection)
        {
            var targetCollection = new List<TestProtocolViewModel>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(TestProtocolMapper.MapToViewModel(element));

            return targetCollection;
        }

        private static ICollection<TestProtocol> ConvertCollection(ICollection<TestProtocolViewModel> sourceCollection)
        {
            var targetCollection = new List<TestProtocol>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(TestProtocolMapper.MapToModel(element));

            return targetCollection;
        }
    }
}
