using EffectCert.DAL.Entities.Contractors;

namespace EffectCert.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<IEnumerable<T>> Find(string searchStr = "");
        Task<int> Create(T address);
        Task<int> Update(T address);
        Task<int> Delete(int id);
    }
}
