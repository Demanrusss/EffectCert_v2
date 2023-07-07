using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.BLL;

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

        public async Task<IEnumerable<CertObject>> Find(string searchStr)
        {
            return await certObjectDAL.Find(searchStr);
        }
    }
}
