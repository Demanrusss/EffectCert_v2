using EffectCert.BLL.Interfaces;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Implementations.Main;
using EffectCert.ViewMappers.Main;
using EffectCert.ViewModels.Main;
using EffectCert.ViewModels.Others;

namespace EffectCert.BLL.Main
{
    public class ApplicationBLL : IApplicationBLL
    {
        private readonly ApplicationRepo applicationDAL;

        public ApplicationBLL (ApplicationRepo applicationDAL)
        {
            this.applicationDAL = applicationDAL;
        }

        public async Task<ApplicationViewModel> Get(int id)
        {
            var application = await applicationDAL.Get(id);

            return ApplicationMapper.MapToViewModel(application);
        }

        public async Task<int> UpdateOrCreate(ApplicationViewModel applicationVM)
        {
            if (applicationVM.ProductsIds != null)
                foreach (var productId in applicationVM.ProductsIds)
                    applicationVM.Products.Add(new ProductViewModel() { Id = productId });

            var application = ApplicationMapper.MapToModel(applicationVM);

            return application.Id == 0 
                ? await applicationDAL.Create(application) 
                : await applicationDAL.Update(application);
        }

        public async Task<ICollection<ApplicationViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var applications = await applicationDAL.Find(searchStr);

            return ConvertCollection(applications);
        }

        public async Task<ICollection<ApplicationViewModel>> FindAll()
        {
            var applications = await applicationDAL.GetAll();

            return ConvertCollection(applications);
        }

        public async Task<int> Delete(int id)
        {
            return await applicationDAL.Delete(id);
        }

        private ICollection<ApplicationViewModel> ConvertCollection(ICollection<Application> collection)
        {
            var collectionVM = new List<ApplicationViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(ApplicationMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
