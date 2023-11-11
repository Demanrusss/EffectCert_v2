using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewMappers.Documents
{
    public static class ContractMapper
    {
        public static Contract MapToModel(ContractViewModel viewModel)
        {
            return new Contract()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                ShortName = viewModel.ShortName,
                Number = viewModel.Number,
                Date = viewModel.Date
            };
        }

        public static ContractViewModel MapToViewModel(Contract model)
        {
            if (model == null)
                return new ContractViewModel();

            return new ContractViewModel()
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
