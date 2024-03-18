using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewModels.Documents;
using EffectCert.ViewModels.Main;

namespace EffectCert.ViewMappers.Documents
{
    public static class GovStandardParagraphsMapper
    {
        public static GovStandardParagraphs MapToModel(GovStandardParagraphsViewModel viewModel)
        {
            return new GovStandardParagraphs()
            {
                GovStandardId = viewModel.GovStandardId,
                Paragraphs = viewModel.Paragraphs ?? String.Empty,
            };
        }

        public static GovStandardParagraphsViewModel MapToViewModel(GovStandardParagraphs model)
        {
            if (model == null)
                return new GovStandardParagraphsViewModel();

            return new GovStandardParagraphsViewModel()
            {
                GovStandard = GovStandardMapper.MapToViewModel(model.GovStandard!),
                Paragraphs = model.Paragraphs
            };
        }
    }
}
