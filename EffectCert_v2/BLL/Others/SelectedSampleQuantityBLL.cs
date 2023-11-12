using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.ViewMappers.Others;
using EffectCert.ViewModels.Others;

namespace EffectCert.BLL.Others
{
    public class SelectedSampleQuantityBLL : ICommonBLL<SelectedSampleQuantityViewModel>
    {
        private readonly SelectedSampleQuantityRepo selectedSampleQuantityDAL;

        public SelectedSampleQuantityBLL(SelectedSampleQuantityRepo selectedSampleQuantityDAL)
        {
            this.selectedSampleQuantityDAL = selectedSampleQuantityDAL;
        }

        public async Task<SelectedSampleQuantityViewModel> Get(int id)
        {
            var selectedSampleQuantity = await selectedSampleQuantityDAL.Get(id);

            return SelectedSampleQuantityMapper.MapToViewModel(selectedSampleQuantity);
        }

        public async Task<int> UpdateOrCreate(SelectedSampleQuantityViewModel selectedSampleQuantityVM)
        {
            var selectedSampleQuantity = SelectedSampleQuantityMapper.MapToModel(selectedSampleQuantityVM);

            return selectedSampleQuantity.Id == 0
                ? await selectedSampleQuantityDAL.Create(selectedSampleQuantity)
                : await selectedSampleQuantityDAL.Update(selectedSampleQuantity);
        }

        public async Task<ICollection<SelectedSampleQuantityViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var selectedSampleQuantities = await selectedSampleQuantityDAL.Find(searchStr);

            return ConvertCollection(selectedSampleQuantities);
        }

        public async Task<ICollection<SelectedSampleQuantityViewModel>> FindAll()
        {
            var selectedSampleQuantities = await selectedSampleQuantityDAL.GetAll();

            return ConvertCollection(selectedSampleQuantities);
        }

        public async Task<int> Delete(int id)
        {
            return await selectedSampleQuantityDAL.Delete(id);
        }

        private ICollection<SelectedSampleQuantityViewModel> ConvertCollection(ICollection<SelectedSampleQuantity> collection)
        {
            var collectionVM = new List<SelectedSampleQuantityViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(SelectedSampleQuantityMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
