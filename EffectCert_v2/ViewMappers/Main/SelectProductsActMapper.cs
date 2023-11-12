using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Entities.Others;
using EffectCert.ViewMappers.Contractors;
using EffectCert.ViewMappers.Others;
using EffectCert.ViewModels.Main;
using EffectCert.ViewModels.Others;

namespace EffectCert.ViewMappers.Main
{
    public static class SelectProductsActMapper
    {
        public static SelectProductsAct MapToModel(SelectProductsActViewModel viewModel)
        {
            return new SelectProductsAct()
            {
                Id = viewModel.Id,
                Number = viewModel.Number,
                ApplicationId = viewModel.ApplicationId,
                Date = viewModel.Date,
                ActionPlanId = viewModel.ActionPlanId,
                AddressId = viewModel.AddressId,
                ControlSamplesQuantity = viewModel.ControlSamplesQuantity,
                ControlSamplesStorageTime = viewModel.ControlSamplesStorageTime,
                PackageType = viewModel.PackageType,
                Products = ConvertCollection(viewModel.Products),
                StorageCondition = viewModel.StorageCondition,
                SupplierId = viewModel.SupplierId
            };
        }

        public static SelectProductsActViewModel MapToViewModel(SelectProductsAct model)
        {
            if (model == null)
                return new SelectProductsActViewModel();

            return new SelectProductsActViewModel()
            {
                Id = model.Id,
                Application = ApplicationMapper.MapToViewModel(model.Application),
                Date = model.Date,
                Number = model.Number,
                ActionPlan = ActionPlanMapper.MapToViewModel(model.ActionPlan),
                Address = AddressMapper.MapToViewModel(model.Address),
                ControlSamplesQuantity = model.ControlSamplesQuantity,
                ControlSamplesStorageTime = model.ControlSamplesStorageTime,
                PackageType = model.PackageType,
                Products = ConvertCollection(model.Products),
                StorageCondition = model.StorageCondition,
                Supplier = ContractorLegalMapper.MapToViewModel(model.Supplier)
            };
        }

        private static ICollection<SelectedSampleQuantityViewModel> ConvertCollection(ICollection<SelectedSampleQuantity> sourceCollection)
        {
            var targetCollection = new List<SelectedSampleQuantityViewModel>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(SelectedSampleQuantityMapper.MapToViewModel(element));

            return targetCollection;
        }

        private static ICollection<SelectedSampleQuantity> ConvertCollection(ICollection<SelectedSampleQuantityViewModel> sourceCollection)
        {
            var targetCollection = new List<SelectedSampleQuantity>(sourceCollection.Count);

            foreach (var element in sourceCollection)
                targetCollection.Add(SelectedSampleQuantityMapper.MapToModel(element));

            return targetCollection;
        }
    }
}
