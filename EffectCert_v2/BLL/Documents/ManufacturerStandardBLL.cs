using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.ViewMappers.Documents;
using EffectCert.ViewModels.Documents;

namespace EffectCert.BLL.Documents
{
    public class ManufacturerStandardBLL : ICommonBLL<ManufacturerStandardViewModel>
    {
        private readonly ManufacturerStandardRepo manufacturerStandardDAL;

        public ManufacturerStandardBLL (ManufacturerStandardRepo manufacturerStandardDAL)
        {
            this.manufacturerStandardDAL = manufacturerStandardDAL;
        }

        public async Task<ManufacturerStandardViewModel> Get(int id)
        {
            var manufacturerStandard = await manufacturerStandardDAL.Get(id);

            return ManufacturerStandardMapper.MapToViewModel(manufacturerStandard);
        }

        public async Task<int> UpdateOrCreate(ManufacturerStandardViewModel manufacturerStandardVM)
        {
            var manufacturerStandard = ManufacturerStandardMapper.MapToModel(manufacturerStandardVM);

            return manufacturerStandard.Id == 0 
                ? await manufacturerStandardDAL.Create(manufacturerStandard) 
                : await manufacturerStandardDAL.Update(manufacturerStandard);
        }

        public async Task<ICollection<ManufacturerStandardViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var manufacturerStandards = await manufacturerStandardDAL.Find(searchStr);

            return ConvertCollection(manufacturerStandards);
        }

        public async Task<ICollection<ManufacturerStandardViewModel>> FindAll()
        {
            var manufacturerStandards = await manufacturerStandardDAL.GetAll();

            return ConvertCollection(manufacturerStandards);
        }

        public async Task<int> Delete(int id)
        {
            return await manufacturerStandardDAL.Delete(id);
        }

        private ICollection<ManufacturerStandardViewModel> ConvertCollection(ICollection<ManufacturerStandard> collection)
        {
            var collectionVM = new List<ManufacturerStandardViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(ManufacturerStandardMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
