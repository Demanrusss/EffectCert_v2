using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.ViewMappers.Others;
using EffectCert.ViewModels.Others;

namespace EffectCert.BLL.Others
{
    public class SchemaBLL : ICommonBLL<SchemaViewModel>
    {
        private readonly SchemaRepo schemaDAL;

        public SchemaBLL(SchemaRepo schemaDAL)
        {
            this.schemaDAL = schemaDAL;
        }

        public async Task<SchemaViewModel> Get(int id)
        {
            var schema = await schemaDAL.Get(id);

            return SchemaMapper.MapToViewModel(schema);
        }

        public async Task<int> UpdateOrCreate(SchemaViewModel schemaVM)
        {
            var schema = SchemaMapper.MapToModel(schemaVM);

            return schema.Id == 0
                ? await schemaDAL.Create(schema)
                : await schemaDAL.Update(schema);
        }

        public async Task<ICollection<SchemaViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var schemas = await schemaDAL.Find(searchStr);

            return ConvertCollection(schemas);
        }

        public async Task<ICollection<SchemaViewModel>> FindAll()
        {
            var schemas = await schemaDAL.GetAll();

            return ConvertCollection(schemas);
        }

        public async Task<int> Delete(int id)
        {
            return await schemaDAL.Delete(id);
        }

        private ICollection<SchemaViewModel> ConvertCollection(ICollection<Schema> collection)
        {
            var collectionVM = new List<SchemaViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(SchemaMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
