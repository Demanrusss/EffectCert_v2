using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using Microsoft.IdentityModel.Tokens;

namespace EffectCert.BLL.Documents
{
    public class ManufacturerStandardBLL : ICommonBLL<ManufacturerStandard>
    {
        private readonly ManufacturerStandardRepo manufacturerStandardDAL;

        public ManufacturerStandardBLL (ManufacturerStandardRepo manufacturerStandardDAL)
        {
            this.manufacturerStandardDAL = manufacturerStandardDAL;
        }

        public async Task<ManufacturerStandard> Get(int id)
        {
            return await manufacturerStandardDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(ManufacturerStandard manufacturerStandard)
        {
            return manufacturerStandard.Id == 0 
                ? await manufacturerStandardDAL.Create(manufacturerStandard) 
                : await manufacturerStandardDAL.Update(manufacturerStandard);
        }

        public async Task<IEnumerable<ManufacturerStandard>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await manufacturerStandardDAL.Find(searchStr);
        }

        public async Task<IEnumerable<ManufacturerStandard>> FindAll()
        {
            return await manufacturerStandardDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await manufacturerStandardDAL.Delete(id);
        }
    }
}
