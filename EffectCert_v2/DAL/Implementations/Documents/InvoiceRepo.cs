using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Documents
{
    public class InvoiceRepo : IRepository<Invoice>
    {
        private readonly AppDBContext appDBContext;

        public InvoiceRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<Invoice>> GetAll()
        {
            return await appDBContext.Invoices.ToListAsync();
        }

        public async Task<Invoice> Get(int id)
        {
            return await appDBContext.Invoices.FirstOrDefaultAsync(a => a.Id == id) ?? new Invoice();
        }

        public async Task<ICollection<Invoice>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            var result = appDBContext.Invoices.Where(c => c.Number.Contains(searchStr)
                                                          || c.Name.Contains(searchStr)
                                                          || c.ShortName.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(Invoice invoice)
        {
            if (invoice == null)
                throw new ArgumentNullException();

            appDBContext.Invoices.Add(invoice);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(Invoice invoice)
        {
            if (invoice == null)
                return 0;

            appDBContext.Invoices.Update(invoice);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Invoice? invoice = await appDBContext.Invoices.FindAsync(id);
            if (invoice == null)
                return 0;

            appDBContext.Invoices.Remove(invoice);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
