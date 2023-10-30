namespace EffectCert.ViewMappers
{
    public interface IMapper<TModel, TViewModel>
    {
        TModel MapFromViewModel(TViewModel viewModel);
        TViewModel MapToViewModel(TModel model);
    }
}
