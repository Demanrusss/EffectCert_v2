using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewMappers.Documents
{
    public static class InvoiceMapper
    {
        public static Invoice MapToModel(InvoiceViewModel viewModel)
        {
            return new Invoice()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                ShortName = viewModel.ShortName,
                Number = viewModel.Number,
                Date = viewModel.Date
            };
        }

        public static InvoiceViewModel MapToViewModel(Invoice model)
        {
            if (model == null)
                return new InvoiceViewModel();

            return new InvoiceViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                ShortName = model.ShortName,
                Number = model.Number,
                Date = model.Date
            };
        }
    }
}
