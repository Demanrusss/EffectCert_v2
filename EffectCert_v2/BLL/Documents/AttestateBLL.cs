using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.BLL;

namespace EffectCert.BLL.Documents
{
    public class AttestateBLL : ICommonBLL<Attestate>
    {
        private readonly AttestateRepo attestateDAL;

        public AttestateBLL(AttestateRepo attestateDAL)
        {
            this.attestateDAL = attestateDAL;
        }

        public async Task<Attestate> Get(int id)
        {
            return await attestateDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(Attestate attestate)
        {
            return attestate.Id == 0 
                ? await attestateDAL.Create(attestate) 
                : await attestateDAL.Update(attestate);
        }

        public async Task<IEnumerable<Attestate>> Find(string searchStr)
        {
            return await attestateDAL.Find(searchStr);
        }
    }
}
