using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using Microsoft.IdentityModel.Tokens;

namespace EffectCert.BLL.Others
{
    public class SchemaBLL : ICommonBLL<Schema>
    {
        private readonly SchemaRepo schemaDAL;

        public SchemaBLL(SchemaRepo schemaDAL)
        {
            this.schemaDAL = schemaDAL;
        }

        public async Task<Schema> Get(int id)
        {
            return await schemaDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(Schema schema)
        {
            return schema.Id == 0
                ? await schemaDAL.Create(schema)
                : await schemaDAL.Update(schema);
        }

        public async Task<IEnumerable<Schema>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await schemaDAL.Find(searchStr);
        }

        public async Task<IEnumerable<Schema>> FindAll()
        {
            return await schemaDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await schemaDAL.Delete(id);
        }
    }
}
