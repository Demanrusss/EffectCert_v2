using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.ViewModels.Documents;
using EffectCert.ViewMappers.Documents;
using EffectCert.BLL.Interfaces;

namespace EffectCert.BLL.Documents
{
    public class CertificateBLL : ICommonBLL<CertificateViewModel>
    {
        private readonly CertificateRepo certificateDAL;

        public CertificateBLL(CertificateRepo certificateDAL)
        {
            this.certificateDAL = certificateDAL;
        }

        public async Task<CertificateViewModel> Get(int id)
        {
            var certificate = await certificateDAL.Get(id);

            return CertificateMapper.MapToViewModel(certificate);
        }

        public async Task<int> UpdateOrCreate(CertificateViewModel certificateVM)
        {
            var certificate = CertificateMapper.MapToModel(certificateVM);

            return certificate.Id == 0 
                ? await certificateDAL.Create(certificate) 
                : await certificateDAL.Update(certificate);
        }

        public async Task<ICollection<CertificateViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var certificates = await certificateDAL.Find(searchStr);

            return ConvertCollection(certificates);
        }

        public async Task<ICollection<CertificateViewModel>> FindAll()
        {
            var certificates = await certificateDAL.GetAll();

            return ConvertCollection(certificates);
        }

        public async Task<int> Delete(int id)
        {
            return await certificateDAL.Delete(id);
        }

        private ICollection<CertificateViewModel> ConvertCollection(ICollection<Certificate> collection)
        {
            var collectionVM = new List<CertificateViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(CertificateMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
