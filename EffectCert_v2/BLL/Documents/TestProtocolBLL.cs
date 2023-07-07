using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.BLL;

namespace EffectCert.BLL.Documents
{
    public class TestProtocolBLL : ICommonBLL<TestProtocol>
    {
        private readonly TestProtocolRepo testProtocolDAL;

        public TestProtocolBLL (TestProtocolRepo testProtocolDAL)
        {
            this.testProtocolDAL = testProtocolDAL;
        }

        public async Task<TestProtocol> Get(int id)
        {
            return await testProtocolDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(TestProtocol testProtocol)
        {
            return testProtocol.Id == 0 
                ? await testProtocolDAL.Create(testProtocol) 
                : await testProtocolDAL.Update(testProtocol);
        }

        public async Task<IEnumerable<TestProtocol>> Find(string searchStr)
        {
            return await testProtocolDAL.Find(searchStr);
        }
    }
}
