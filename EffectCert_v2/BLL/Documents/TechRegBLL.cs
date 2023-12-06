using EffectCert.BLL.Interfaces;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.ViewMappers.Documents;
using EffectCert.ViewModels.Documents;

namespace EffectCert.BLL.Documents
{
    public class TechRegBLL : ICommonBLL<TechRegViewModel>
    {
        private readonly TechRegRepo techRegDAL;

        public TechRegBLL (TechRegRepo techRegDAL)
        {
            this.techRegDAL = techRegDAL;
        }

        public async Task<TechRegViewModel> Get(int id)
        {
            var techReg = await techRegDAL.Get(id);

            return TechRegMapper.MapToViewModel(techReg);
        }

        public async Task<int> UpdateOrCreate(TechRegViewModel techRegVM)
        {
            var techReg = TechRegMapper.MapToModel(techRegVM);

            return techReg.Id == 0 
                ? await techRegDAL.Create(techReg) 
                : await techRegDAL.Update(techReg);
        }

        public async Task<ICollection<TechRegViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();
            
            var techRegs = await techRegDAL.Find(searchStr);

            return ConvertCollection(techRegs);
        }

        public async Task<ICollection<TechRegViewModel>> FindAll()
        {
            var techRegs = await techRegDAL.GetAll();

            return ConvertCollection(techRegs);
        }

        public async Task<int> Delete(int id)
        {
            return await techRegDAL.Delete(id);
        }

        private ICollection<TechRegViewModel> ConvertCollection(ICollection<TechReg> collection)
        {
            var collectionVM = new List<TechRegViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(TechRegMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
