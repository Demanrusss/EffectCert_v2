using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.BLL;

namespace EffectCert.BLL.Others
{
    public class ProductQuantityBLL : ICommonBLL<ProductQuantity>
    {
        private readonly ProductQuantityRepo productQuantityDAL;

        public ProductQuantityBLL(ProductQuantityRepo productQuantityDAL)
        {
            this.productQuantityDAL = productQuantityDAL;
        }

        public async Task<ProductQuantity> Get(int id)
        {
            return await productQuantityDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(ProductQuantity productQuantity)
        {
            return productQuantity.Id == 0
                ? await productQuantityDAL.Create(productQuantity)
                : await productQuantityDAL.Update(productQuantity);
        }

        public async Task<IEnumerable<ProductQuantity>> Find(string searchStr)
        {
            return await productQuantityDAL.Find(searchStr);
        }
    }
}
