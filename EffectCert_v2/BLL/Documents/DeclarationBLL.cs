using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.BLL;

namespace EffectCert.BLL.Documents
{
    public class DeclarationBLL : ICommonBLL<Declaration>
    {
        private readonly DeclarationRepo declarationDAL;

        public DeclarationBLL(DeclarationRepo declarationDAL)
        {
            this.declarationDAL = declarationDAL;
        }

        public async Task<Declaration> Get(int id)
        {
            return await declarationDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(Declaration declaration)
        {
            return declaration.Id == 0 
                ? await declarationDAL.Create(declaration) 
                : await declarationDAL.Update(declaration);
        }

        public async Task<IEnumerable<Declaration>> Find(string searchStr)
        {
            return await declarationDAL.Find(searchStr);
        }
    }
}
