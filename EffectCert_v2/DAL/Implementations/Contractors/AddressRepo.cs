using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Contractors
{
    public class AddressRepo : IRepository<Address>
    {
        private readonly AppDBContext appDBContext;

        public AddressRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<IEnumerable<Address>> GetAll()
        {
            return await appDBContext.Addresses.ToListAsync();
        }

        public async Task<Address> Get(int id)
        {
            return await appDBContext.Addresses.FirstOrDefaultAsync(a => a.Id == id) ?? new Address();
        }

        public async Task<IEnumerable<Address>> Find(string searchStr = "")
        {
            var result = appDBContext.Addresses.Where(c => c.AddressLine != null ? c.AddressLine.Contains(searchStr) : c.Country.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(Address address)
        {
            if (address == null)
                throw new ArgumentNullException();

            appDBContext.Addresses.Add(address);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(Address address)
        {
            if (address == null)
                return 0;

            appDBContext.Addresses.Update(address);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Address? address = await appDBContext.Addresses.FindAsync(id);
            if (address == null)
                return 0;

            appDBContext.Addresses.Remove(address);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
