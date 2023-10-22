using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.BLL;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Entities.Contractors;
using Microsoft.IdentityModel.Tokens;

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

        public async Task<ICollection<Declaration>> Find(string searchStr)
        {
            if (searchStr.IsNullOrEmpty())
                return await FindAll();

            return await declarationDAL.Find(searchStr);
        }

        public async Task<ICollection<Declaration>> FindAll()
        {
            return await declarationDAL.GetAll();
        }

        public async Task<int> Delete(int id)
        {
            return await declarationDAL.Delete(id);
        }
    }
}
