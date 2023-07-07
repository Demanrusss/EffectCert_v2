using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Implementations.Main;
using EffectCert.BLL;

namespace EffectCert.BLL.Main
{
    public class ApplicationBLL : ICommonBLL<Application>
    {
        private readonly ApplicationRepo applicationDAL;

        public ApplicationBLL (ApplicationRepo applicationDAL)
        {
            this.applicationDAL = applicationDAL;
        }

        public async Task<Application> Get(int id)
        {
            return await applicationDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(Application application)
        {
            return application.Id == 0 
                ? await applicationDAL.Create(application) 
                : await applicationDAL.Update(application);
        }

        public async Task<IEnumerable<Application>> Find(string searchStr)
        {
            return await applicationDAL.Find(searchStr);
        }
    }
}
