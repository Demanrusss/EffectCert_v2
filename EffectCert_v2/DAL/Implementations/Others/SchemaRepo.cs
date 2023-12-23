using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Others
{
    public class SchemaRepo : IRepository<Schema>
    {
        private readonly AppDBContext appDBContext;

        public SchemaRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<Schema>> GetAll()
        {
            return await appDBContext.Schemas
                .Include(s => s.CertObjects)
                .ToListAsync();
        }

        public async Task<Schema> Get(int id)
        {
            return await appDBContext.Schemas
                .Include(s => s.CertObjects)
                .FirstOrDefaultAsync(a => a.Id == id) ?? new Schema();
        }

        public async Task<ICollection<Schema>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.Schemas
                .Include(s => s.CertObjects)
                .Where(c => c.Name.Contains(searchStr))
                .ToListAsync();
        }

        public async Task<int> Create(Schema schema)
        {
            if (schema == null)
                return 0;

            var certObjectsIds = new HashSet<int>();
            foreach (var certObject in schema.CertObjects)
                certObjectsIds.Add(certObject.Id);

            schema.CertObjects = new HashSet<CertObject>();

            appDBContext.Schemas.Add(schema);
            await appDBContext.SaveChangesAsync();

            foreach (var certObject in certObjectsIds)
                appDBContext.SchemasCertObjects.Add(new SchemasCertObjects() { SchemaId = schema.Id, CertObjectId = certObject });

            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(Schema schema)
        {
            if (schema == null)
                return 0;

            var schemaCertObjectsIds = new HashSet<int>();
            foreach (var certObject in schema.CertObjects)
                schemaCertObjectsIds.Add(certObject.Id);

            schema.CertObjects = new HashSet<CertObject>();
            appDBContext.Schemas.Update(schema);

            IEnumerable<int> existedSchemaCertObjectsIds = appDBContext.SchemasCertObjects.Where(sco => sco.SchemaId == schema.Id).Select(sco => sco.CertObjectId);

            foreach (var certObjectToAddId in schemaCertObjectsIds.Except(existedSchemaCertObjectsIds))
                appDBContext.SchemasCertObjects.Add(new SchemasCertObjects() { SchemaId = schema.Id, CertObjectId = certObjectToAddId });

            foreach (var id in existedSchemaCertObjectsIds.Except(schemaCertObjectsIds))
                appDBContext.SchemasCertObjects.Remove(new SchemasCertObjects() { SchemaId = schema.Id, CertObjectId = id });

            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Schema? schema = await appDBContext.Schemas.FindAsync(id);
            if (schema == null)
                return 0;

            appDBContext.Schemas.Remove(schema);
            return await appDBContext.SaveChangesAsync();
        }
    }
}
