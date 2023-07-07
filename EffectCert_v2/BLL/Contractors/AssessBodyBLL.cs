using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.BLL;

namespace EffectCert.BLL.Contractors
{
    public class AssessBodyBLL : ICommonBLL<AssessBody>
    {
        private readonly AssessBodyRepo assessBodyDAL;

        public AssessBodyBLL(AssessBodyRepo assessBodyDAL)
        {
            this.assessBodyDAL = assessBodyDAL;
        }

        public async Task<AssessBody> Get(int id)
        {
            return await assessBodyDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(AssessBody assessBody)
        {
            return assessBody.Id == 0 
                ? await assessBodyDAL.Create(assessBody) 
                : await assessBodyDAL.Update(assessBody);
        }

        public async Task<IEnumerable<AssessBody>> Find(string searchStr)
        {
            return await assessBodyDAL.Find(searchStr);
        }
    }
}
