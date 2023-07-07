using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.BLL;

namespace EffectCert.BLL.Contractors
{
    public class LaboratoryBLL : ICommonBLL<Laboratory>
    {
        private readonly LaboratoryRepo laboratoryDAL;

        public LaboratoryBLL(LaboratoryRepo laboratoryDAL)
        {
            this.laboratoryDAL = laboratoryDAL;
        }

        public async Task<Laboratory> Get(int id)
        {
            return await laboratoryDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(Laboratory laboratory)
        {
            return laboratory.Id == 0 
                ? await laboratoryDAL.Create(laboratory) 
                : await laboratoryDAL.Update(laboratory);
        }

        public async Task<IEnumerable<Laboratory>> Find(string searchStr)
        {
            return await laboratoryDAL.Find(searchStr);
        }
    }
}
