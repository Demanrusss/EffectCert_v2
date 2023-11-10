using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.ViewMappers.Contractors;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.BLL.Contractors
{
    public class AssessBodyEmployeeBLL : ICommonBLL<AssessBodyEmployeeViewModel>
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

        public async Task<int> UpdateOrCreate(AssessBodyEmployeeViewModel assessBodyEmployeeViewModel)
        {
            var assessBodyEmployee = AssessBodyEmployeeMapper.MapToModel(assessBodyEmployeeViewModel);

            return assessBodyEmployee.Id == 0 
                ? await assessBodyEmployeeDAL.Create(assessBodyEmployee) 
                : await assessBodyEmployeeDAL.Update(assessBodyEmployee);
        }

        public async Task<ICollection<AssessBodyEmployeeViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var assessBodyEmployees = await assessBodyEmployeeDAL.Find(searchStr);

            return ConvertAssessBodyCollection(assessBodyEmployees);
        }

        public async Task<ICollection<AssessBodyEmployeeViewModel>> FindAll()
        {
            var assessBodyEmployees = await assessBodyEmployeeDAL.GetAll();
            return ConvertAssessBodyCollection(assessBodyEmployees);
        }

        public async Task<int> Delete(int id)
        {
            return await assessBodyEmployeeDAL.Delete(id);
        }

        private ICollection<AssessBodyEmployeeViewModel> ConvertAssessBodyCollection(ICollection<AssessBodyEmployee> assessBodyEmployees)
        {
            var assessBodyEmployeesVM = new List<AssessBodyEmployeeViewModel>(assessBodyEmployees.Count);

            foreach (var assessBodyEmployee in assessBodyEmployees)
                assessBodyEmployeesVM.Add(AssessBodyEmployeeMapper.MapToViewModel(assessBodyEmployee));

            return assessBodyEmployeesVM;
        }
    }
}
