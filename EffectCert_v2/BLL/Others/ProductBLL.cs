using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.ViewMappers.Others;
using EffectCert.ViewModels.Others;

namespace EffectCert.BLL.Others
{
    public class ProductBLL : ICommonBLL<ProductViewModel>
    {
        private readonly ProductRepo productDAL;

        public ProductBLL(ProductRepo productDAL)
        {
            this.productDAL = productDAL;
        }

        public async Task<ProductViewModel> Get(int id)
        {
            var product = await productDAL.Get(id);

            return ProductMapper.MapToViewModel(product);
        }

        public async Task<int> UpdateOrCreate(ProductViewModel productVM)
        {
            var product = ProductMapper.MapToModel(productVM);

            return product.Id == 0
                ? await productDAL.Create(product)
                : await productDAL.Update(product);
        }

        public async Task<ICollection<ProductViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var products = await productDAL.Find(searchStr);

            return ConvertCollection(products);
        }

        public async Task<ICollection<ProductViewModel>> FindAll()
        {
            var products = await productDAL.GetAll();

            return ConvertCollection(products);
        }

        public async Task<int> Delete(int id)
        {
            return await productDAL.Delete(id);
        }

        private ICollection<ProductViewModel> ConvertCollection(ICollection<Product> collection)
        {
            var collectionVM = new List<ProductViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(ProductMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
