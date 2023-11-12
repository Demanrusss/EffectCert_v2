using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Entities.Others;
using EffectCert.ViewMappers.Contractors;
using EffectCert.ViewMappers.Others;
using EffectCert.ViewModels.Main;
using EffectCert.ViewModels.Others;

namespace EffectCert.ViewMappers.Main
{
    public static class RecommendationMapper
    {
        public static Recommendation MapToModel(RecommendationViewModel viewModel)
        {
            return new Recommendation()
            {
                Id = viewModel.Id,
                Date = viewModel.Date,
                Number = viewModel.Number,
                ApplicationId = viewModel.ApplicationId,
                SelectProductsActId = viewModel.SelectProductsActId,
                DecisionId = viewModel.DecisionId,
                ExpertDecisionId = viewModel.ExpertDecisionId
            };
        }

        public static RecommendationViewModel MapToViewModel(Recommendation model)
        {
            if (model == null)
                return new RecommendationViewModel();

            return new RecommendationViewModel()
            {
                Id = model.Id,
                Date = model.Date,
                Number = model.Number,
                Application = ApplicationMapper.MapToViewModel(model.Application),
                SelectProductsAct = SelectProductsActMapper.MapToViewModel(model.SelectProductsAct),
                Decision = AppDecisionMapper.MapToViewModel(model.Decision),
                ExpertDecision = ExpertDecisionMapper.MapToViewModel(model.ExpertDecision)
            };
        }
    }
}
