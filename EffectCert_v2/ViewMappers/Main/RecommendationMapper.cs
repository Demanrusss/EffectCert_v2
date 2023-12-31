﻿using EffectCert.DAL.Entities.Main;
using EffectCert.ViewModels.Main;

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
                AppDecisionId = viewModel.DecisionId,
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
                Decision = AppDecisionMapper.MapToViewModel(model.AppDecision),
                ExpertDecision = ExpertDecisionMapper.MapToViewModel(model.ExpertDecision)
            };
        }
    }
}
