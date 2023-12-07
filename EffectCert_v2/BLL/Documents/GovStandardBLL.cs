using EffectCert.BLL.Interfaces;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.ViewMappers.Documents;
using EffectCert.ViewModels.Documents;

namespace EffectCert.BLL.Documents
{
    public class GovStandardBLL : IGovStandardBLL
    {
        private readonly GovStandardRepo govStandardDAL;

        public GovStandardBLL(GovStandardRepo govStandardDAL)
        {
            this.govStandardDAL = govStandardDAL;
        }

        public async Task<GovStandardViewModel> Get(int id)
        {
            var govStandard = await govStandardDAL.Get(id);

            return GovStandardMapper.MapToViewModel(govStandard);
        }

        public async Task<int> UpdateOrCreate(GovStandardViewModel govStandardVM)
        {
            var govStandard = GovStandardMapper.MapToModel(govStandardVM);

            return govStandard.Id == 0 
                ? await govStandardDAL.Create(govStandard) 
                : await govStandardDAL.Update(govStandard);
        }

        public async Task<ICollection<GovStandardViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var govStandards = await govStandardDAL.Find(searchStr);

            return ConvertCollection(govStandards);
        }

        public async Task<ICollection<GovStandardViewModel>> FindAll()
        {
            var govStandards = await govStandardDAL.GetAll();

            return ConvertCollection(govStandards);
        }

        public async Task<int> Delete(int id)
        {
            return await govStandardDAL.Delete(id);
        }

        private ICollection<GovStandardViewModel> ConvertCollection(ICollection<GovStandard> collection)
        {
            var collectionVM = new List<GovStandardViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(GovStandardMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
