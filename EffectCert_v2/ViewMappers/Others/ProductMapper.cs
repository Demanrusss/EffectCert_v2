using EffectCert.DAL.Entities.Others;
using EffectCert.ViewMappers.Contractors;
using EffectCert.ViewModels.Others;

namespace EffectCert.ViewMappers.Others
{
    public static class ProductMapper
    {
        public static Product MapToModel(ProductViewModel viewModel)
        {
            return new Product()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Article = viewModel.Article,
                GroupName = viewModel.GroupName,
                ManufacturerId = viewModel.ManufacturerId,
                Model = viewModel.Model,
                TNVED = viewModel.TNVED,
                TradeMark = viewModel.TradeMark,
                Type = viewModel.Type
            };
        }

        public static ProductViewModel MapToViewModel(Product model)
        {
            if (model == null)
                return new ProductViewModel();

            return new ProductViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Article = model.Article,
                GroupName = model.GroupName,
                Manufacturer = ContractorLegalMapper.MapToViewModel(model.Manufacturer),
                Model = model.Model,
                TNVED = model.TNVED,
                TradeMark = model.TradeMark,
                Type = model.Type
            };
        }
    }
}
