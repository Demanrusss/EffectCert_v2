using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Others
{
    public class MeasurementUnitRepo : IRepository<MeasurementUnit>
    {
        private readonly AppDBContext appDBContext;

        public MeasurementUnitRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<MeasurementUnit>> GetAll()
        {
            return await appDBContext.MeasurementUnits.ToListAsync();
        }

        public async Task<MeasurementUnit> Get(int id)
        {
            return await appDBContext.MeasurementUnits.FirstOrDefaultAsync(a => a.Id == id) ?? new MeasurementUnit();
        }

        public async Task<ICollection<MeasurementUnit>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            var result = appDBContext.MeasurementUnits.Where(c => c.Name.Contains(searchStr) 
                                                                  || c.ShortName.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(MeasurementUnit measurementUnit)
        {
            if (measurementUnit == null)
                throw new ArgumentNullException();

            appDBContext.MeasurementUnits.Add(measurementUnit);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(MeasurementUnit measurementUnit)
        {
            if (measurementUnit == null)
                return 0;

            appDBContext.MeasurementUnits.Update(measurementUnit);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            MeasurementUnit? measurementUnit = await appDBContext.MeasurementUnits.FindAsync(id);
            if (measurementUnit == null)
                return 0;

            appDBContext.MeasurementUnits.Remove(measurementUnit);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
