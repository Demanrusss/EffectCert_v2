using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Entities.Others;
using EffectCert.ViewMappers.Contractors;
using EffectCert.ViewMappers.Documents;
using EffectCert.ViewMappers.Others;
using EffectCert.ViewModels.Documents;
using EffectCert.ViewModels.Main;
using EffectCert.ViewModels.Others;

namespace EffectCert.ViewMappers.Main
{
    public static class ApplicationMapper
    {
        public static Application MapToModel(ApplicationViewModel viewModel)
        {
            return new Application()
            {
                Id = viewModel.Id,
                AssessBodyId = viewModel.AssessBodyId,
                ContractorLegalId = viewModel.ContractorLegalId,
                Date = viewModel.Date,
                ElectronicDate = viewModel.ElectronicDate,
                ElectronicNumber = viewModel.ElectronicNumber,
                Number = viewModel.Number,
                Products = ConvertCollection(viewModel.Products),
                ProductQuantities = ConvertCollection(viewModel.ProductQuantities),
                SchemaId = viewModel.SchemaId,
                Contracts = ConvertCollection(viewModel.Contracts),
                GTDs = ConvertCollection(viewModel.GTDs),
                Invoices = ConvertCollection(viewModel.Invoices),
                TechRegsParagraphs = ConvertCollection(viewModel.TechRegParagraphs),
                GovStandardsParagraphs = ConvertCollection(viewModel.GovStandardParagraphs)
            };
        }

        public static ApplicationViewModel MapToViewModel(Application model)
        {
            if (model == null)
                return new ApplicationViewModel();

            return new ApplicationViewModel()
            {
                Id = model.Id,
                AssessBody = AssessBodyMapper.MapToViewModel(model.AssessBody),
                ContractorLegal = ContractorLegalMapper.MapToViewModel(model.ContractorLegal),
                Date = model.Date,
                ElectronicDate = model.ElectronicDate,
                ElectronicNumber = model.ElectronicNumber,
                Number = model.Number,
                Products = ConvertCollection(model.Products),
                ProductQuantities = ConvertCollection(model.ProductQuantities),
                Schema = SchemaMapper.MapToViewModel(model.Schema),
                Contracts = ConvertCollection(model.Contracts),
                GTDs = ConvertCollection(model.GTDs),
                Invoices = ConvertCollection(model.Invoices),
                TechRegParagraphs = (IList<TechRegParagraphsViewModel>)ConvertCollection(model.TechRegsParagraphs),
                GovStandardParagraphs = (IList<GovStandardParagraphsViewModel>)ConvertCollection(model.GovStandardsParagraphs)
            };
        }

        private static ICollection<ProductViewModel> ConvertCollection(ICollection<Product> sourceCollection)
        {
            var targetCollection = new List<ProductViewModel>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(ProductMapper.MapToViewModel(element));

            return targetCollection;
        }

        private static ICollection<Product> ConvertCollection(ICollection<ProductViewModel> sourceCollection)
        {
            var targetCollection = new List<Product>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(ProductMapper.MapToModel(element));

            return targetCollection;
        }

        private static ICollection<ProductQuantityViewModel> ConvertCollection(ICollection<ProductQuantity> sourceCollection)
        {
            var targetCollection = new List<ProductQuantityViewModel>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(ProductQuantityMapper.MapToViewModel(element));

            return targetCollection;
        }

        private static ICollection<ProductQuantity> ConvertCollection(ICollection<ProductQuantityViewModel> sourceCollection)
        {
            var targetCollection = new List<ProductQuantity>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(ProductQuantityMapper.MapToModel(element));

            return targetCollection;
        }

        private static ICollection<TechRegParagraphsViewModel> ConvertCollection(ICollection<TechRegParagraphs> sourceCollection)
        {
            var targetCollection = new List<TechRegParagraphsViewModel>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(TechRegParagraphsMapper.MapToViewModel(element));

            return targetCollection;
        }

        private static ICollection<TechRegParagraphs> ConvertCollection(ICollection<TechRegParagraphsViewModel> sourceCollection)
        {
            var targetCollection = new List<TechRegParagraphs>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(TechRegParagraphsMapper.MapToModel(element));

            return targetCollection;
        }

        private static ICollection<GovStandardParagraphsViewModel> ConvertCollection(ICollection<GovStandardParagraphs> sourceCollection)
        {
            var targetCollection = new List<GovStandardParagraphsViewModel>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(GovStandardParagraphsMapper.MapToViewModel(element));

            return targetCollection;
        }

        private static ICollection<GovStandardParagraphs> ConvertCollection(ICollection<GovStandardParagraphsViewModel> sourceCollection)
        {
            var targetCollection = new List<GovStandardParagraphs>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(GovStandardParagraphsMapper.MapToModel(element));

            return targetCollection;
        }

        private static ICollection<ContractViewModel> ConvertCollection(ICollection<Contract> sourceCollection)
        {
            var targetCollection = new List<ContractViewModel>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(ContractMapper.MapToViewModel(element));

            return targetCollection;
        }

        private static ICollection<Contract> ConvertCollection(ICollection<ContractViewModel> sourceCollection)
        {
            var targetCollection = new List<Contract>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(ContractMapper.MapToModel(element));

            return targetCollection;
        }

        private static ICollection<GTDViewModel> ConvertCollection(ICollection<GTD> sourceCollection)
        {
            var targetCollection = new List<GTDViewModel>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(GTDMapper.MapToViewModel(element));

            return targetCollection;
        }

        private static ICollection<GTD> ConvertCollection(ICollection<GTDViewModel> sourceCollection)
        {
            var targetCollection = new List<GTD>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(GTDMapper.MapToModel(element));

            return targetCollection;
        }

        private static ICollection<InvoiceViewModel> ConvertCollection(ICollection<Invoice> sourceCollection)
        {
            var targetCollection = new List<InvoiceViewModel>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(InvoiceMapper.MapToViewModel(element));

            return targetCollection;
        }

        private static ICollection<Invoice> ConvertCollection(ICollection<InvoiceViewModel> sourceCollection)
        {
            var targetCollection = new List<Invoice>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(InvoiceMapper.MapToModel(element));

            return targetCollection;
        }
    }
}
