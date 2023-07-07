using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.BLL;

namespace EffectCert.BLL.Others
{
    public class SelectedSampleQuantityBLL : ICommonBLL<SelectedSampleQuantity>
    {
        private readonly SelectedSampleQuantityRepo selectedSampleQuantityDAL;

        public SelectedSampleQuantityBLL(SelectedSampleQuantityRepo selectedSampleQuantityDAL)
        {
            this.selectedSampleQuantityDAL = selectedSampleQuantityDAL;
        }

        public async Task<SelectedSampleQuantity> Get(int id)
        {
            return await selectedSampleQuantityDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(SelectedSampleQuantity selectedSampleQuantity)
        {
            return selectedSampleQuantity.Id == 0
                ? await selectedSampleQuantityDAL.Create(selectedSampleQuantity)
                : await selectedSampleQuantityDAL.Update(selectedSampleQuantity);
        }

        public async Task<IEnumerable<SelectedSampleQuantity>> Find(string searchStr)
        {
            return await selectedSampleQuantityDAL.Find(searchStr);
        }
    }
}
