using EffectCert.DAL.Entities.Documents;
using EffectCert.ViewMappers.Contractors;
using EffectCert.ViewModels.Documents;

namespace EffectCert.ViewMappers.Documents
{
    public static class TestProtocolMapper
    {
        public static TestProtocol MapToModel(TestProtocolViewModel viewModel)
        {
            return new TestProtocol()
            {
                Id = viewModel.Id,
                Date = viewModel.Date,
                Number = viewModel.Number,
                LaboratoryId = viewModel.LaboratoryId
            };
        }

        public static TestProtocolViewModel MapToViewModel(TestProtocol model)
        {
            if (model == null)
                return new TestProtocolViewModel();

            return new TestProtocolViewModel()
            {
                Id = model.Id,
                Date = model.Date,
                Number = model.Number,
                Laboratory = LaboratoryMapper.MapToViewModel(model.Laboratory),
            };
        }
    }
}
