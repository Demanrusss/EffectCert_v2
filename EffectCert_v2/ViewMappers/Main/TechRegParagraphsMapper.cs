using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Entities.Main;
using EffectCert.ViewModels.Documents;
using EffectCert.ViewModels.Main;

namespace EffectCert.ViewMappers.Documents
{
    public static class TechRegParagraphsMapper
    {
        public static TechRegParagraphs MapToModel(TechRegParagraphsViewModel viewModel)
        {
            return new TechRegParagraphs()
            {
                TechRegId = viewModel.TechRegId,
                Paragraphs = viewModel.Paragraphs
            };
        }

        public static TechRegParagraphsViewModel MapToViewModel(TechRegParagraphs model)
        {
            if (model == null)
                return new TechRegParagraphsViewModel();

            return new TechRegParagraphsViewModel()
            {
                TechReg = TechRegMapper.MapToViewModel(model.TechReg!),
                Paragraphs = model.Paragraphs
            };
        }
    }
}
