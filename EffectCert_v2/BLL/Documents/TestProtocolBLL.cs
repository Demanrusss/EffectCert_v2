using EffectCert.BLL.Interfaces;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.ViewMappers.Documents;
using EffectCert.ViewModels.Documents;

namespace EffectCert.BLL.Documents
{
    public class TestProtocolBLL : ICommonBLL<TestProtocolViewModel>
    {
        private readonly TestProtocolRepo testProtocolDAL;

        public TestProtocolBLL (TestProtocolRepo testProtocolDAL)
        {
            this.testProtocolDAL = testProtocolDAL;
        }

        public async Task<TestProtocolViewModel> Get(int id)
        {
            var testProtocol = await testProtocolDAL.Get(id);

            return TestProtocolMapper.MapToViewModel(testProtocol);
        }

        public async Task<int> UpdateOrCreate(TestProtocolViewModel testProtocolVM)
        {
            var testProtocol = TestProtocolMapper.MapToModel(testProtocolVM);

            return testProtocol.Id == 0 
                ? await testProtocolDAL.Create(testProtocol) 
                : await testProtocolDAL.Update(testProtocol);
        }

        public async Task<ICollection<TestProtocolViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();

            var testProtocols = await testProtocolDAL.Find(searchStr);

            return ConvertCollection(testProtocols);
        }

        public async Task<ICollection<TestProtocolViewModel>> FindAll()
        {
            var testProtocols = await testProtocolDAL.GetAll();

            return ConvertCollection(testProtocols);
        }

        public async Task<int> Delete(int id)
        {
            return await testProtocolDAL.Delete(id);
        }

        private ICollection<TestProtocolViewModel> ConvertCollection(ICollection<TestProtocol> collection)
        {
            var collectionVM = new List<TestProtocolViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(TestProtocolMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
