using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Main;
using EffectCert.ViewMappers.Contractors;
using EffectCert.ViewModels.Main;

namespace EffectCert.ViewMappers.Main
{
    public static class ActionPlanMapper
    {
        public static ActionPlan MapToModel(ActionPlanViewModel viewModel)
        {
            return new ActionPlan()
            {
                Id = viewModel.Id,
                Number = viewModel.Number,
                AppAnalizeExpertId = viewModel.AppAnalizeExpertId,
                ApplicationId = viewModel.ApplicationId,
                ConformityAssessBodyHeadId = viewModel.ConformityAssessBodyHeadId,
                ResultsAnalizeExpertId = viewModel.ResultsAnalizeExpertId,
                Date = viewModel.Date,
                RegDocumentEmployeeId = viewModel.RegDocumentEmployeeId,
                SelectProductEmployeeId = viewModel.SelectProductEmployeeId
            };
        }

        public static ActionPlanViewModel MapToViewModel(ActionPlan model)
        {
            if (model == null)
                return new ActionPlanViewModel();

            return new ActionPlanViewModel()
            {
                Id = model.Id,
                AppAnalizeExpert = AssessBodyEmployeeMapper.MapToViewModel(model.AppAnalizeExpert),
                Application = ApplicationMapper.MapToViewModel(model.Application),
                ConformityAssessBodyHead = AssessBodyEmployeeMapper.MapToViewModel(model.ConformityAssessBodyHead),
                ResultsAnalizeExpert = AssessBodyEmployeeMapper.MapToViewModel(model.ResultsAnalizeExpert ?? new AssessBodyEmployee()),
                Date = model.Date,
                Number = model.Number,
                RegDocumentEmployee = AssessBodyEmployeeMapper.MapToViewModel(model.RegDocumentEmployee ?? new AssessBodyEmployee()),
                SelectProductEmployee = ContractorLegalEmployeeMapper.MapToViewModel(model.SelectProductEmployee ?? new ContractorLegalEmployee())
            };
        }
    }
}
