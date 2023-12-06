using EffectCert.BLL.Interfaces;
using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.ViewMappers.Others;
using EffectCert.ViewModels.Others;

namespace EffectCert.BLL.Others
{
    public class InconsistenceBLL : ICommonBLL<InconsistenceViewModel>
    {
        private readonly InconsistenceRepo inconsistenceDAL;

        public InconsistenceBLL(InconsistenceRepo inconsistenceDAL)
        {
            this.inconsistenceDAL = inconsistenceDAL;
        }

        public async Task<InconsistenceViewModel> Get(int id)
        {
            var inconsistence = await inconsistenceDAL.Get(id);

            return InconsistenceMapper.MapToViewModel(inconsistence);
        }

        public async Task<int> UpdateOrCreate(InconsistenceViewModel inconsistenceVM)
        {
            var inconsistence = InconsistenceMapper.MapToModel(inconsistenceVM);

            return inconsistence.Id == 0
                ? await inconsistenceDAL.Create(inconsistence)
                : await inconsistenceDAL.Update(inconsistence);
        }

        public async Task<ICollection<InconsistenceViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var inconsistences = await inconsistenceDAL.Find(searchStr);

            return ConvertCollection(inconsistences);
        }

        public async Task<ICollection<InconsistenceViewModel>> FindAll()
        {
            var inconsistences = await inconsistenceDAL.GetAll();

            return ConvertCollection(inconsistences);
        }

        public async Task<int> Delete(int id)
        {
            return await inconsistenceDAL.Delete(id);
        }

        private ICollection<InconsistenceViewModel> ConvertCollection(ICollection<Inconsistence> collection)
        {
            var collectionVM = new List<InconsistenceViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(InconsistenceMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
