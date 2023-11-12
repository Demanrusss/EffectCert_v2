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
                Name = viewModel.Name
            };
        }

        public static SchemaViewModel MapToViewModel(Schema model)
        {
            if (model == null)
                return new SchemaViewModel();

            return new SchemaViewModel()
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
