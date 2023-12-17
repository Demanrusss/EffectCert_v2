using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.ViewModels.Contractors;
using EffectCert.ViewMappers.Contractors;
using EffectCert.BLL.Interfaces;

namespace EffectCert.BLL.Contractors
{
    public class AssessBodyBLL : IAssessBodyBLL
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

        public async Task<int> UpdateOrCreate(AssessBodyViewModel assessBodyVM)
        {
            if (assessBodyVM.EmployeesIds != null)
                foreach (var employee in assessBodyVM.EmployeesIds)
                    assessBodyVM.Employees.Add(new AssessBodyEmployeeViewModel() { Id = employee });

            var assessBody = AssessBodyMapper.MapToModel(assessBodyVM);

            return assessBody.Id == 0 
                ? await assessBodyDAL.Create(assessBody) 
                : await assessBodyDAL.Update(assessBody);
        }

        public async Task<ICollection<AssessBodyViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var assessBodies = await assessBodyDAL.Find(searchStr);

            return ConvertCollection(assessBodies);
        }

        public async Task<ICollection<AssessBodyViewModel>> FindAll()
        {
            var assessBodies = await assessBodyDAL.GetAll();

            return ConvertCollection(assessBodies);
        }

        public async Task<int> Delete(int id)
        {
            return await assessBodyDAL.Delete(id);
        }

        private ICollection<AssessBodyViewModel> ConvertCollection(ICollection<AssessBody> collection)
        {
            var collectionVM = new List<AssessBodyViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(AssessBodyMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
