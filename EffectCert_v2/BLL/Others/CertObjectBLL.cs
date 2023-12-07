using EffectCert.BLL.Interfaces;
using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.ViewMappers.Others;
using EffectCert.ViewModels.Others;

namespace EffectCert.BLL.Others
{
    public class CertObjectBLL : ICertObjectBLL
    {
        private readonly CertObjectRepo certObjectDAL;

        public CertObjectBLL(CertObjectRepo certObjectDAL)
        {
            this.certObjectDAL = certObjectDAL;
        }

        public async Task<CertObjectViewModel> Get(int id)
        {
            var certObject = await certObjectDAL.Get(id);

            return CertObjectMapper.MapToViewModel(certObject);
        }

        public async Task<int> UpdateOrCreate(CertObjectViewModel certObjectVM)
        {
            var certObject = CertObjectMapper.MapToModel(certObjectVM);

            return certObject.Id == 0
                ? await certObjectDAL.Create(certObject)
                : await certObjectDAL.Update(certObject);
        }

        public async Task<ICollection<CertObjectViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var certObjects = await certObjectDAL.Find(searchStr);

            return ConvertCollection(certObjects);
        }

        public async Task<ICollection<CertObjectViewModel>> FindAll()
        {
            var certObjects = await certObjectDAL.GetAll();

            return ConvertCollection(certObjects);
        }

        public async Task<int> Delete(int id)
        {
            return await certObjectDAL.Delete(id);
        }

        private ICollection<CertObjectViewModel> ConvertCollection(ICollection<CertObject> collection)
        {
            var collectionVM = new List<CertObjectViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(CertObjectMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
