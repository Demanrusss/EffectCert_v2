using EffectCert.BLL.Interfaces;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.ViewMappers.Contractors;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.BLL.Contractors
{
    public class LaboratoryBLL : ILaboratoryBLL
    {
        private readonly LaboratoryRepo laboratoryDAL;

        public LaboratoryBLL(LaboratoryRepo laboratoryDAL)
        {
            this.laboratoryDAL = laboratoryDAL;
        }

        public async Task<LaboratoryViewModel> Get(int id)
        {
            var laboratory = await laboratoryDAL.Get(id);

            return LaboratoryMapper.MapToViewModel(laboratory);
        }

        public async Task<int> UpdateOrCreate(LaboratoryViewModel laboratoryVM)
        {
            var laboratory = LaboratoryMapper.MapToModel(laboratoryVM);

            return laboratory.Id == 0 
                ? await laboratoryDAL.Create(laboratory) 
                : await laboratoryDAL.Update(laboratory);
        }

        public async Task<ICollection<LaboratoryViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var laboratories = await laboratoryDAL.Find(searchStr);

            return ConvertCollection(laboratories);
        }

        public async Task<ICollection<LaboratoryViewModel>> FindAll()
        {
            var laboratories = await laboratoryDAL.GetAll();

            return ConvertCollection(laboratories);
        }

        public async Task<int> Delete(int id)
        {
            return await laboratoryDAL.Delete(id);
        }

        private ICollection<LaboratoryViewModel> ConvertCollection(ICollection<Laboratory> collection)
        {
            var collectionVM = new List<LaboratoryViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(LaboratoryMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
