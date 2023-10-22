using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using Microsoft.IdentityModel.Tokens;

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

        public async Task<ICollection<Certificate>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await certificateDAL.Find(searchStr);
        }

        public async Task<ICollection<Certificate>> FindAll()
        {
            return await certificateDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await certificateDAL.Delete(id);
        }
    }
}
