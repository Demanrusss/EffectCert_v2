using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.ViewMappers.Contractors;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.BLL.Contractors
{
    public class LaboratoryEmployeeBLL : ICommonBLL<LaboratoryEmployeeViewModel>
    {
        private readonly LaboratoryEmployeeRepo laboratoryEmployeeDAL;

        public LaboratoryEmployeeBLL(LaboratoryEmployeeRepo laboratoryEmployeeDAL)
        {
            this.laboratoryEmployeeDAL = laboratoryEmployeeDAL;
        }

        public async Task<LaboratoryEmployeeViewModel> Get(int id)
        {
            var laboratoryEmployee = await laboratoryEmployeeDAL.Get(id);

            return LaboratoryEmployeeMapper.MapToViewModel(laboratoryEmployee);
        }

        public async Task<int> UpdateOrCreate(LaboratoryEmployeeViewModel laboratoryEmployeeVM)
        {
            var laboratoryEmployee = LaboratoryEmployeeMapper.MapToModel(laboratoryEmployeeVM);

            return laboratoryEmployee.Id == 0 
                ? await laboratoryEmployeeDAL.Create(laboratoryEmployee) 
                : await laboratoryEmployeeDAL.Update(laboratoryEmployee);
        }

        public async Task<ICollection<LaboratoryEmployeeViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var laboratories = await laboratoryEmployeeDAL.Find(searchStr);

            return ConvertCollection(laboratories);
        }

        public async Task<ICollection<LaboratoryEmployeeViewModel>> FindAll()
        {
            var laboratories = await laboratoryEmployeeDAL.GetAll();

            return ConvertCollection(laboratories);
        }

        public async Task<int> Delete(int id)
        {
            return await laboratoryEmployeeDAL.Delete(id);
        }

        private ICollection<LaboratoryEmployeeViewModel> ConvertCollection(ICollection<LaboratoryEmployee> collection)
        {
            var collectionVM = new List<LaboratoryEmployeeViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(LaboratoryEmployeeMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
