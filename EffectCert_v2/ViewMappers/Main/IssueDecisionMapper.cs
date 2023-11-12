using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Entities.Main;
using EffectCert.ViewMappers.Documents;
using EffectCert.ViewModels.Main;

namespace EffectCert.ViewMappers.Main
{
    public static class IssueDecisionMapper
    {
        public static IssueDecision MapToModel(IssueDecisionViewModel viewModel)
        {
            return new IssueDecision()
            {
                Id = viewModel.Id,
                Date = viewModel.Date,
                Number = viewModel.Number,
                ApplicationId = viewModel.ApplicationId,
                CertificateId = viewModel.CertificateId,
                DeclarationId = viewModel.DeclarationId,
                ExpertDecisionId = viewModel.ExpertDecisionId,
                RecommendationId = viewModel.RecommendationId
            };
        }

        public static IssueDecisionViewModel MapToViewModel(IssueDecision model)
        {
            if (model == null)
                return new IssueDecisionViewModel();

            return new IssueDecisionViewModel()
            {
                Id = model.Id,
                Date = model.Date,
                Number = model.Number,
                Application = ApplicationMapper.MapToViewModel(model.Application),
                Certificate = CertificateMapper.MapToViewModel(model.Certificate ?? new Certificate()),
                Declaration = DeclarationMapper.MapToViewModel(model.Declaration ?? new Declaration()),
                ExpertDecision = ExpertDecisionMapper.MapToViewModel(model.ExpertDecision),
                Recommendation = RecommendationMapper.MapToViewModel(model.Recommendation)
            };
        }
    }
}
