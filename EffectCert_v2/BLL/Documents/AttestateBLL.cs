using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using Microsoft.IdentityModel.Tokens;
using EffectCert.ViewModels.Documents;
using EffectCert.ViewMappers.Contractors;
using EffectCert.ViewModels.Contractors;

namespace EffectCert.BLL.Documents
{
    public class AttestateBLL : ICommonBLL<AttestateViewModel>
    {
        private readonly AttestateRepo attestateDAL;

        public AttestateBLL(AttestateRepo attestateDAL)
        {
            this.attestateDAL = attestateDAL;
        }

        public async Task<AttestateViewModel> Get(int id)
        {
            var attestate = await attestateDAL.Get(id);

            return AttestateMapper.MapToViewModel(attestate);
        }

        public async Task<int> UpdateOrCreate(AttestateViewModel attestateViewModel)
        {
            var attestate = AttestateMapper.MapToModel(attestateViewModel);

            return attestate.Id == 0 
                ? await attestateDAL.Create(attestate) 
                : await attestateDAL.Update(attestate);
        }

        public async Task<ICollection<AttestateViewModel>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            var attestates = await attestateDAL.Find(searchStr);

            return ConvertAssessBodyCollection(attestates);
        }

        public async Task<ICollection<AttestateViewModel>> FindAll()
        {
            var attestates = await attestateDAL.GetAll();

            return ConvertAssessBodyCollection(attestates);
        }

        public async Task<int> Delete(int id)
        {
            return await attestateDAL.Delete(id);
        }

        private ICollection<AttestateViewModel> ConvertAssessBodyCollection(ICollection<Attestate> attestates)
        {
            var attestatesVM = new List<AttestateViewModel>(attestates.Count);

            foreach (var assessBody in attestates)
                attestatesVM.Add(AttestateMapper.MapToViewModel(assessBody));

            return attestatesVM;
        }
    }
}
