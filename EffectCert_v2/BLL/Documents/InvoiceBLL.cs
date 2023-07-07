using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.BLL;

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

        public async Task<IEnumerable<Invoice>> Find(string searchStr)
        {
            return await invoiceDAL.Find(searchStr);
        }
    }
}
