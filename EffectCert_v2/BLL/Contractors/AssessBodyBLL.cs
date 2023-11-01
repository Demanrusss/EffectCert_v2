using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.BLL;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewMappers.Contractors;

namespace EffectCert.BLL.Contractors
{
    public class AssessBodyBLL : ICommonBLL<AssessBodyViewModel>
    {
        private readonly AssessBodyRepo assessBodyDAL;

        public AssessBodyBLL(AssessBodyRepo assessBodyDAL)
        {
            this.assessBodyDAL = assessBodyDAL;
        }

        public async Task<AssessBodyViewModel> Get(int id)
        {
            var assessBody = await assessBodyDAL.Get(id);

            return AssessBodyMapper.MapToViewModel(assessBody);
        }

        public async Task<int> UpdateOrCreate(AssessBodyViewModel assessBodyViewModel)
        {
            var assessBody = AssessBodyMapper.MapToModel(assessBodyViewModel);

            return assessBody.Id == 0 
                ? await assessBodyDAL.Create(assessBody) 
                : await assessBodyDAL.Update(assessBody);
        }

        public async Task<ICollection<AssessBodyViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var assessBodies = await assessBodyDAL.Find(searchStr);

            return ConvertAssessBodyCollection(assessBodies);
        }

        public async Task<ICollection<AssessBodyViewModel>> FindAll()
        {
            var assessBodies = await assessBodyDAL.GetAll();

            return ConvertAssessBodyCollection(assessBodies);
        }

        public async Task<int> Delete(int id)
        {
            return await assessBodyDAL.Delete(id);
        }

        private ICollection<AssessBodyViewModel> ConvertAssessBodyCollection(ICollection<AssessBody> assessBodies)
        {
            var assessBodiesVM = new List<AssessBodyViewModel>(assessBodies.Count);

            foreach (var assessBody in assessBodies)
                assessBodiesVM.Add(AssessBodyMapper.MapToViewModel(assessBody));

            return assessBodiesVM;
        }
    }
}
