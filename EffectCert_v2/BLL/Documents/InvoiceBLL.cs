using EffectCert.BLL.Interfaces;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.ViewMappers.Documents;
using EffectCert.ViewModels.Documents;

namespace EffectCert.BLL.Documents
{
    public class InvoiceBLL : IInvoiceBLL
    {
        private readonly InvoiceRepo invoiceDAL;

        public InvoiceBLL (InvoiceRepo invoiceDAL)
        {
            this.invoiceDAL = invoiceDAL;
        }

        public async Task<InvoiceViewModel> Get(int id)
        {
            var invoice = await invoiceDAL.Get(id);

            return InvoiceMapper.MapToViewModel(invoice);
        }

        public async Task<int> UpdateOrCreate(InvoiceViewModel invoiceVM)
        {
            var invoice = InvoiceMapper.MapToModel(invoiceVM);

            return invoice.Id == 0 
                ? await invoiceDAL.Create(invoice) 
                : await invoiceDAL.Update(invoice);
        }

        public async Task<ICollection<InvoiceViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var invoices = await invoiceDAL.Find(searchStr);

            return ConvertCollection(invoices);
        }

        public async Task<ICollection<InvoiceViewModel>> FindAll()
        {
            var invoices = await invoiceDAL.GetAll();

            return ConvertCollection(invoices);
        }

        public async Task<int> Delete(int id)
        {
            return await invoiceDAL.Delete(id);
        }

        private ICollection<InvoiceViewModel> ConvertCollection(ICollection<Invoice> collection)
        {
            var collectionVM = new List<InvoiceViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(InvoiceMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
