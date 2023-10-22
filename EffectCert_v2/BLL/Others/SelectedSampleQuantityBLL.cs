using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;

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

        public async Task<ICollection<SelectedSampleQuantity>> Find(string searchStr)
        {
            if (searchStr.IsNormalized())
                return await FindAll();

            return await selectedSampleQuantityDAL.Find(searchStr);
        }

        public async Task<ICollection<SelectedSampleQuantity>> FindAll()
        {
            return await selectedSampleQuantityDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await selectedSampleQuantityDAL.Delete(id);
        }
    }
}
