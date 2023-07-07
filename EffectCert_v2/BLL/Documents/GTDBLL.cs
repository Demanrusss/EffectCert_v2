using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.BLL;

namespace EffectCert.BLL.Documents
{
    public class GTDBLL : ICommonBLL<GTD>
    {
        private readonly GTDRepo gTDDAL;

        public GTDBLL(GTDRepo gTDDAL)
        {
            this.gTDDAL = gTDDAL;
        }

        public async Task<GTD> Get(int id)
        {
            return await gTDDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(GTD gTD)
        {
            return gTD.Id == 0 
                ? await gTDDAL.Create(gTD) 
                : await gTDDAL.Update(gTD);
        }

        public async Task<IEnumerable<GTD>> Find(string searchStr)
        {
            return await gTDDAL.Find(searchStr);
        }
    }
}
