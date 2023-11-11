using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.ViewModels.Documents;
using EffectCert.ViewMappers.Documents;

namespace EffectCert.BLL.Documents
{
    public class AttestateBLL : ICommonBLL<AttestateViewModel>
    {
        private readonly AttestateRepo attestateDAL;

        public AttestateBLL(AttestateRepo attestateDAL)
        {
            this.attestateDAL = attestateDAL;
        }

        public async Task<AttestateViewModel> Get(int id)
        {
            var attestate = await attestateDAL.Get(id);

            return AttestateMapper.MapToViewModel(attestate);
        }

        public async Task<int> UpdateOrCreate(AttestateViewModel attestateVM)
        {
            var attestate = AttestateMapper.MapToModel(attestateVM);

            return attestate.Id == 0 
                ? await attestateDAL.Create(attestate) 
                : await attestateDAL.Update(attestate);
        }

        public async Task<ICollection<AttestateViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var attestates = await attestateDAL.Find(searchStr);

            return ConvertCollection(attestates);
        }

        public async Task<ICollection<AttestateViewModel>> FindAll()
        {
            var attestates = await attestateDAL.GetAll();

            return ConvertCollection(attestates);
        }

        public async Task<int> Delete(int id)
        {
            return await attestateDAL.Delete(id);
        }

        private ICollection<AttestateViewModel> ConvertCollection(ICollection<Attestate> collection)
        {
            var collectionVM = new List<AttestateViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(AttestateMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
