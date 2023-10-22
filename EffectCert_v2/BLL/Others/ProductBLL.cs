using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using Microsoft.IdentityModel.Tokens;

namespace EffectCert.BLL.Others
{
    public class ProductBLL : ICommonBLL<Product>
    {
        private readonly ProductRepo productDAL;

        public ProductBLL(ProductRepo productDAL)
        {
            this.productDAL = productDAL;
        }

        public async Task<Product> Get(int id)
        {
            return await productDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(Product product)
        {
            return product.Id == 0
                ? await productDAL.Create(product)
                : await productDAL.Update(product);
        }

        public async Task<ICollection<Product>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await productDAL.Find(searchStr);
        }

        public async Task<ICollection<Product>> FindAll()
        {
            return await productDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await productDAL.Delete(id);
        }
    }
}
