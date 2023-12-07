using EffectCert.BLL.Interfaces;
using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.ViewMappers.Others;
using EffectCert.ViewModels.Others;

namespace EffectCert.BLL.Others
{
    public class MeasurementUnitBLL : IMeasurementUnitBLL
    {
        private readonly MeasurementUnitRepo measurementUnitDAL;

        public MeasurementUnitBLL(MeasurementUnitRepo measurementUnitDAL)
        {
            this.measurementUnitDAL = measurementUnitDAL;
        }

        public async Task<MeasurementUnitViewModel> Get(int id)
        {
            var measurementUnit = await measurementUnitDAL.Get(id);

            return MeasurementUnitMapper.MapToViewModel(measurementUnit);
        }

        public async Task<int> UpdateOrCreate(MeasurementUnitViewModel measurementUnitVM)
        {
            var measurementUnit = MeasurementUnitMapper.MapToModel(measurementUnitVM);

            return measurementUnit.Id == 0
                ? await measurementUnitDAL.Create(measurementUnit)
                : await measurementUnitDAL.Update(measurementUnit);
        }

        public async Task<ICollection<MeasurementUnitViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var measurementUnits = await measurementUnitDAL.Find(searchStr);

            return ConvertCollection(measurementUnits);
        }

        public async Task<ICollection<MeasurementUnitViewModel>> FindAll()
        {
            var measurementUnits = await measurementUnitDAL.GetAll();

            return ConvertCollection(measurementUnits);
        }

        public async Task<int> Delete(int id)
        {
            return await measurementUnitDAL.Delete(id);
        }

        private ICollection<MeasurementUnitViewModel> ConvertCollection(ICollection<MeasurementUnit> collection)
        {
            var collectionVM = new List<MeasurementUnitViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(MeasurementUnitMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
