using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.BLL;

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

        public async Task<IEnumerable<Product>> Find(string searchStr)
        {
            return await productDAL.Find(searchStr);
        }
    }
}
