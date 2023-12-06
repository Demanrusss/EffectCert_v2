using EffectCert.BLL.Interfaces;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.ViewMappers.Contractors;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.BLL.Contractors
{
    public class AssessBodyEmployeeBLL : IAssessBodyEmployeeBLL
    {
        private readonly AssessBodyEmployeeRepo assessBodyEmployeeDAL;

        public AssessBodyEmployeeBLL(AssessBodyEmployeeRepo assessBodyEmployeeDAL)
        {
            this.assessBodyEmployeeDAL = assessBodyEmployeeDAL;
        }

        public async Task<AssessBodyEmployeeViewModel> Get(int id)
        {
            var assessBodyEmployee = await assessBodyEmployeeDAL.Get(id);
            return AssessBodyEmployeeMapper.MapToViewModel(assessBodyEmployee);
        }

        public async Task<int> UpdateOrCreate(AssessBodyEmployeeViewModel assessBodyEmployeeVM)
        {
            var assessBodyEmployee = AssessBodyEmployeeMapper.MapToModel(assessBodyEmployeeVM);

            return assessBodyEmployee.Id == 0 
                ? await assessBodyEmployeeDAL.Create(assessBodyEmployee) 
                : await assessBodyEmployeeDAL.Update(assessBodyEmployee);
        }

        public async Task<ICollection<AssessBodyEmployeeViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var assessBodyEmployees = await assessBodyEmployeeDAL.Find(searchStr);

            return ConvertCollection(assessBodyEmployees);
        }

        public async Task<ICollection<AssessBodyEmployeeViewModel>> FindAll()
        {
            var assessBodyEmployees = await assessBodyEmployeeDAL.GetAll();
            return ConvertCollection(assessBodyEmployees);
        }

        public async Task<int> Delete(int id)
        {
            return await assessBodyEmployeeDAL.Delete(id);
        }

        private ICollection<AssessBodyEmployeeViewModel> ConvertCollection(ICollection<AssessBodyEmployee> collection)
        {
            var collectionVM = new List<AssessBodyEmployeeViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(AssessBodyEmployeeMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
