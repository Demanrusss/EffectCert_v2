﻿using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Entities.Others;
using EffectCert.ViewMappers.Contractors;
using EffectCert.ViewMappers.Documents;
using EffectCert.ViewMappers.Others;
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

        private static ICollection<GovStandardParagraphs> ConvertCollection(ICollection<GovStandardParagraphsViewModel> sourceCollection)
        {
            var targetCollection = new List<GovStandardParagraphs>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(GovStandardParagraphsMapper.MapToModel(element));

            return targetCollection;
        }
    }
}
