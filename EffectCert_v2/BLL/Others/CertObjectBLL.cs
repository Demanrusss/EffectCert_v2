using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using Microsoft.IdentityModel.Tokens;

namespace EffectCert.BLL.Others
{
    public class CertObjectBLL : ICommonBLL<CertObject>
    {
        private readonly CertObjectRepo certObjectDAL;

        public CertObjectBLL(CertObjectRepo certObjectDAL)
        {
            this.certObjectDAL = certObjectDAL;
        }

        public async Task<CertObject> Get(int id)
        {
            return await certObjectDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(CertObject certObject)
        {
            return certObject.Id == 0
                ? await certObjectDAL.Create(certObject)
                : await certObjectDAL.Update(certObject);
        }

        public async Task<ICollection<CertObject>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await certObjectDAL.Find(searchStr);
        }

        public async Task<ICollection<CertObject>> FindAll()
        {
            return await certObjectDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await certObjectDAL.Delete(id);
        }
    }
}
