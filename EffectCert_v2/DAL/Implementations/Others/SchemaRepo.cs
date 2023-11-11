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
            return await appDBContext.Schemas.ToListAsync();
        }

        public async Task<Schema> Get(int id)
        {
            return await appDBContext.Schemas.FirstOrDefaultAsync(a => a.Id == id) ?? new Schema();
        }

        public async Task<ICollection<Schema>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            var result = appDBContext.Schemas.Where(c => c.Name.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(Schema schema)
        {
            if (schema == null)
                throw new ArgumentNullException();

            appDBContext.Schemas.Add(schema);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(Schema schema)
        {
            if (schema == null)
                return 0;

            appDBContext.Schemas.Update(schema);
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
