using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewMappers.Documents
{
    public static class TechRegMapper
    {
        public static TechReg MapToModel(TechRegViewModel viewModel)
        {
            return new TechReg()
            {
                Id = viewModel.Id,
                Number = viewModel.Number,
                Name = viewModel.Name,
                ShortName= viewModel.ShortName,
                ApprovedByInfo = viewModel.ApprovedByInfo,
                Paragraphs = viewModel.Paragraphs
            };
        }

        public static TechRegViewModel MapToViewModel(TechReg model)
        {
            if (model == null)
                return new TechRegViewModel();

            return new TechRegViewModel()
            {
                Id = model.Id,
                Number = model.Number,
                Name = model.Name,
                ShortName = model.ShortName,
                ApprovedByInfo = model.ApprovedByInfo,
                Paragraphs = model.Paragraphs
            };
        }
    }
}
