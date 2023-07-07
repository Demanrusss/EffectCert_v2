using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Implementations.Main;
using EffectCert.BLL;

namespace EffectCert.BLL.Main
{
    public class SelectProductsActBLL : ICommonBLL<SelectProductsAct>
    {
        private readonly SelectProductsActRepo selectProductsActDAL;

        public SelectProductsActBLL (SelectProductsActRepo selectProductsActDAL)
        {
            this.selectProductsActDAL = selectProductsActDAL;
        }

        public async Task<SelectProductsAct> Get(int id)
        {
            return await selectProductsActDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(SelectProductsAct selectProductsAct)
        {
            return selectProductsAct.Id == 0 
                ? await selectProductsActDAL.Create(selectProductsAct) 
                : await selectProductsActDAL.Update(selectProductsAct);
        }

        public async Task<IEnumerable<SelectProductsAct>> Find(string searchStr)
        {
            return await selectProductsActDAL.Find(searchStr);
        }
    }
}
