using EffectCert.DAL.Entities.Others;
using EffectCert.ViewModels.Others;

namespace EffectCert.ViewMappers.Others
{
    public static class SchemaMapper
    {
        public static Schema MapToModel(SchemaViewModel viewModel)
        {
            return new Schema()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                CertObjects = ConvertCollection(viewModel.CertObjects)
            };
        }

        public static SchemaViewModel MapToViewModel(Schema model)
        {
            if (model == null)
                return new SchemaViewModel();

            return new SchemaViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                CertObjects = ConvertCollection(model.CertObjects)
            };
        }

        private static ICollection<CertObjectViewModel> ConvertCollection(ICollection<CertObject> sourceCollection)
        {
            var targetCollection = new List<CertObjectViewModel>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(CertObjectMapper.MapToViewModel(element));

            return targetCollection;
        }

        private static ICollection<CertObject> ConvertCollection(ICollection<CertObjectViewModel> sourceCollection)
        {
            var targetCollection = new List<CertObject>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(CertObjectMapper.MapToModel(element));

            return targetCollection;
        }
    }
}
