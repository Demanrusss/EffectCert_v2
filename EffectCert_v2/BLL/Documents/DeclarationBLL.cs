using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.ViewMappers.Documents;
using EffectCert.ViewModels.Documents;

namespace EffectCert.BLL.Documents
{
    public class DeclarationBLL : ICommonBLL<DeclarationViewModel>
    {
        private readonly DeclarationRepo declarationDAL;

        public DeclarationBLL(DeclarationRepo declarationDAL)
        {
            this.declarationDAL = declarationDAL;
        }

        public async Task<DeclarationViewModel> Get(int id)
        {
            var declaration = await declarationDAL.Get(id);

            return DeclarationMapper.MapToViewModel(declaration);
        }

        public async Task<int> UpdateOrCreate(DeclarationViewModel declarationVM)
        {
            var declaration = DeclarationMapper.MapToModel(declarationVM);

            return declaration.Id == 0 
                ? await declarationDAL.Create(declaration) 
                : await declarationDAL.Update(declaration);
        }

        public async Task<ICollection<DeclarationViewModel>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await FindAll();
            
            var declarations = await declarationDAL.Find(searchStr);

            return ConvertCollection(declarations);
        }

        public async Task<ICollection<DeclarationViewModel>> FindAll()
        {
            var declarations = await declarationDAL.GetAll();

            return ConvertCollection(declarations);
        }

        public async Task<int> Delete(int id)
        {
            return await declarationDAL.Delete(id);
        }

        private ICollection<DeclarationViewModel> ConvertCollection(ICollection<Declaration> collection)
        {
            var collectionVM = new List<DeclarationViewModel>(collection.Count);

            foreach (var element in collection)
                collectionVM.Add(DeclarationMapper.MapToViewModel(element));

            return collectionVM;
        }
    }
}
