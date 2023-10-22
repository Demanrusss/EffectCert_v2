using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using Microsoft.IdentityModel.Tokens;

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

        public async Task<ICollection<ProductQuantity>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await productQuantityDAL.Find(searchStr);
        }

        public async Task<ICollection<ProductQuantity>> FindAll()
        {
            return await productQuantityDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await productQuantityDAL.Delete(id);
        }
    }
}
