using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.BLL;

namespace EffectCert.BLL.Others
{
    public class MeasurementUnitBLL : ICommonBLL<MeasurementUnit>
    {
        private readonly MeasurementUnitRepo measurementUnitDAL;

        public MeasurementUnitBLL(MeasurementUnitRepo measurementUnitDAL)
        {
            this.measurementUnitDAL = measurementUnitDAL;
        }

        public async Task<MeasurementUnit> Get(int id)
        {
            return await measurementUnitDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(MeasurementUnit measurementUnit)
        {
            return measurementUnit.Id == 0
                ? await measurementUnitDAL.Create(measurementUnit)
                : await measurementUnitDAL.Update(measurementUnit);
        }

        public async Task<IEnumerable<MeasurementUnit>> Find(string searchStr)
        {
            return await measurementUnitDAL.Find(searchStr);
        }
    }
}
