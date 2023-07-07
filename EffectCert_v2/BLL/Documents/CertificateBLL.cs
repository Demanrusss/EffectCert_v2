using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.BLL;

namespace EffectCert.BLL.Documents
{
    public class CertificateBLL : ICommonBLL<Certificate>
    {
        private readonly CertificateRepo certificateDAL;

        public CertificateBLL(CertificateRepo certificateDAL)
        {
            this.certificateDAL = certificateDAL;
        }

        public async Task<Certificate> Get(int id)
        {
            return await certificateDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(Certificate certificate)
        {
            return certificate.Id == 0 
                ? await certificateDAL.Create(certificate) 
                : await certificateDAL.Update(certificate);
        }

        public async Task<IEnumerable<Certificate>> Find(string searchStr)
        {
            return await certificateDAL.Find(searchStr);
        }
    }
}
