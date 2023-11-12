using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Entities.Others;
using EffectCert.ViewMappers.Contractors;
using EffectCert.ViewMappers.Others;
using EffectCert.ViewModels.Main;

namespace EffectCert.ViewMappers.Main
{
    public static class AppDecisionMapper
    {
        public static AppDecision MapToModel(AppDecisionViewModel viewModel)
        {
            return new AppDecision()
            {
                Id = viewModel.Id,
                Number = viewModel.Number,
                ApplicationId = viewModel.ApplicationId,
                Date = viewModel.Date,
                ActionPlanId = viewModel.ActionPlanId,
                AssessContractDate = viewModel.AssessContractDate,
                AssessContractNumber = viewModel.AssessContractNumber,
                InspectionAssessBodyId = viewModel.InspectionAssessBodyId,
                ProductionAnalyzeAssessBodyId = viewModel.ProductionAnalyzeAssessBodyId,
                ProductionAnalyzeLaboratoryId = viewModel.ProductionAnalyzeLaboratoryId,
                SchemaAnotherId = viewModel.SchemaAnotherId,
                DeclarationDate = viewModel.DeclarationDate,
                InspectionLaboratoryId = viewModel.InspectionLaboratoryId,
                DeclarationNumber = viewModel.DeclarationNumber,
                InspectionPeriod = viewModel.InspectionPeriod
            };
        }

        public static AppDecisionViewModel MapToViewModel(AppDecision model)
        {
            if (model == null)
                return new AppDecisionViewModel();

            return new AppDecisionViewModel()
            {
                Id = model.Id,
                Application = ApplicationMapper.MapToViewModel(model.Application),
                Date = model.Date,
                Number = model.Number,
                ActionPlan = ActionPlanMapper.MapToViewModel(model.ActionPlan),
                AssessContractDate = model.AssessContractDate,
                AssessContractNumber = model.AssessContractNumber,
                InspectionAssessBody = AssessBodyMapper.MapToViewModel(model.InspectionAssessBody ?? new AssessBody()),
                ProductionAnalyzeAssessBody = AssessBodyMapper.MapToViewModel(model.ProductionAnalyzeAssessBody ?? new AssessBody()),
                ProductionAnalyzeLaboratory = LaboratoryMapper.MapToViewModel(model.ProductionAnalyzeLaboratory ?? new Laboratory()),
                SchemaAnother = SchemaMapper.MapToViewModel(model.SchemaAnother ?? new Schema()),
                DeclarationDate = model.DeclarationDate,
                DeclarationNumber = model.DeclarationNumber,
                InspectionLaboratory = LaboratoryMapper.MapToViewModel(model.InspectionLaboratory ?? new Laboratory()),
                InspectionPeriod = model.InspectionPeriod
            };
        }
    }
}
