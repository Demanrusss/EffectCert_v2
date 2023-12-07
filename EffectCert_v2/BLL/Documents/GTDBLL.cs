using EffectCert.BLL.Interfaces;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.ViewMappers.Documents;
using EffectCert.ViewModels.Documents;

namespace EffectCert.BLL.Documents
{
    public class GTDBLL : IGTDBLL
    {
        private readonly GTDRepo gTDDAL;

        public GTDBLL(GTDRepo gTDDAL)
        {
            this.gTDDAL = gTDDAL;
        }

        public async Task<GTDViewModel> Get(int id)
        {
            var gTD = await gTDDAL.Get(id);

            return GTDMapper.MapToViewModel(gTD);
        }

        public async Task<int> UpdateOrCreate(GTDViewModel gTDVM)
        {
            var gTD = GTDMapper.MapToModel(gTDVM);

            return gTD.Id == 0 
                ? await gTDDAL.Create(gTD) 
                : await gTDDAL.Update(gTD);
        }

        public async Task<ICollection<GTDViewModel>> Find(string searchStr)
        {

            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var gTDs = await gTDDAL.Find(searchStr);

            return ConvertCollection(gTDs);
        }

        public async Task<ICollection<GTDViewModel>> FindAll()
        {
            var gTDs = await gTDDAL.GetAll();

            return ConvertCollection(gTDs);
        }

        public async Task<int> Delete(int id)
        {
            return await gTDDAL.Delete(id);
        }

        private ICollection<GTDViewModel> ConvertCollection(ICollection<GTD> collection)
        {
            var collectionVM = new List<GTDViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(GTDMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
