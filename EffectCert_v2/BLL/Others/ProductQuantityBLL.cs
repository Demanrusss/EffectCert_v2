using EffectCert.BLL.Interfaces;
using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.ViewMappers.Others;
using EffectCert.ViewModels.Others;

namespace EffectCert.BLL.Others
{
    public class ProductQuantityBLL : IProductQuantityBLL
    {
        private readonly ProductQuantityRepo productQuantityDAL;

        public ProductQuantityBLL(ProductQuantityRepo productQuantityDAL)
        {
            this.productQuantityDAL = productQuantityDAL;
        }

        public async Task<ProductQuantityViewModel> Get(int id)
        {
            var productQuantity = await productQuantityDAL.Get(id);

            return ProductQuantityMapper.MapToViewModel(productQuantity);
        }

        public async Task<int> UpdateOrCreate(ProductQuantityViewModel productQuantityVM)
        {
            var productQuantity = ProductQuantityMapper.MapToModel(productQuantityVM);

            return productQuantity.Id == 0
                ? await productQuantityDAL.Create(productQuantity)
                : await productQuantityDAL.Update(productQuantity);
        }

        public async Task<ICollection<ProductQuantityViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var productQuantities = await productQuantityDAL.Find(searchStr);

            return ConvertCollection(productQuantities);
        }

        public async Task<ICollection<ProductQuantityViewModel>> FindAll()
        {
            var productQuantities = await productQuantityDAL.GetAll();

            return ConvertCollection(productQuantities);
        }

        public async Task<int> Delete(int id)
        {
            return await productQuantityDAL.Delete(id);
        }

        private ICollection<ProductQuantityViewModel> ConvertCollection(ICollection<ProductQuantity> collection)
        {
            var collectionVM = new List<ProductQuantityViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(ProductQuantityMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
