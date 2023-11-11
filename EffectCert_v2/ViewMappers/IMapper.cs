namespace EffectCert.ViewMappers
{
    public interface IMapper<TModel, TViewModel>
    {
        TModel MapToModel(TViewModel viewModel);
        TViewModel MapToViewModel(TModel model);
    }
}
