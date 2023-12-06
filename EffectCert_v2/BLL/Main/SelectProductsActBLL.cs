using EffectCert.BLL.Interfaces;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Implementations.Main;
using EffectCert.ViewMappers.Main;
using EffectCert.ViewModels.Main;

namespace EffectCert.BLL.Main
{
    public class SelectProductsActBLL : ICommonBLL<SelectProductsActViewModel>
    {
        private readonly SelectProductsActRepo selectProductsActDAL;

        public SelectProductsActBLL (SelectProductsActRepo selectProductsActDAL)
        {
            this.selectProductsActDAL = selectProductsActDAL;
        }

        public async Task<SelectProductsActViewModel> Get(int id)
        {
            var selectProductsAct = await selectProductsActDAL.Get(id);

            return SelectProductsActMapper.MapToViewModel(selectProductsAct);
        }

        public async Task<int> UpdateOrCreate(SelectProductsActViewModel selectProductsActVM)
        {
            var selectProductsAct = SelectProductsActMapper.MapToModel(selectProductsActVM);

            return selectProductsAct.Id == 0 
                ? await selectProductsActDAL.Create(selectProductsAct) 
                : await selectProductsActDAL.Update(selectProductsAct);
        }

        public async Task<ICollection<SelectProductsActViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var selectProductsActs = await selectProductsActDAL.Find(searchStr);

            return ConvertCollection(selectProductsActs);
        }

        public async Task<ICollection<SelectProductsActViewModel>> FindAll()
        {
            var selectProductsActs = await selectProductsActDAL.GetAll();

            return ConvertCollection(selectProductsActs);
        }

        public async Task<int> Delete(int id)
        {
            return await selectProductsActDAL.Delete(id);
        }

        private ICollection<SelectProductsActViewModel> ConvertCollection(ICollection<SelectProductsAct> collection)
        {
            var collectionVM = new List<SelectProductsActViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(SelectProductsActMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
