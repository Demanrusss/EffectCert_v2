using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.BLL;
using Microsoft.IdentityModel.Tokens;

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

        public async Task<ICollection<Laboratory>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await laboratoryDAL.Find(searchStr);
        }

        public async Task<ICollection<Laboratory>> FindAll()
        {
            return await laboratoryDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await laboratoryDAL.Delete(id);
        }
    }
}
