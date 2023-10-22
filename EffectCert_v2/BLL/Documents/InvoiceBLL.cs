using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using Microsoft.IdentityModel.Tokens;

namespace EffectCert.BLL.Documents
{
    public class InvoiceBLL : ICommonBLL<Invoice>
    {
        private readonly InvoiceRepo invoiceDAL;

        public InvoiceBLL (InvoiceRepo invoiceDAL)
        {
            this.invoiceDAL = invoiceDAL;
        }

        public async Task<Invoice> Get(int id)
        {
            return await invoiceDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(Invoice invoice)
        {
            return invoice.Id == 0 
                ? await invoiceDAL.Create(invoice) 
                : await invoiceDAL.Update(invoice);
        }

        public async Task<ICollection<Invoice>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await invoiceDAL.Find(searchStr);
        }

        public async Task<ICollection<Invoice>> FindAll()
        {
            return await invoiceDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await invoiceDAL.Delete(id);
        }
    }
}
