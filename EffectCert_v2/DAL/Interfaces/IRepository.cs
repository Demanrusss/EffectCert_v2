using EffectCert.DAL.Entities.Contractors;

namespace EffectCert.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<ICollection<T>> GetAll();
        Task<T> Get(int id);
        Task<ICollection<T>> Find(string searchStr);
        Task<int> Create(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(int id);
    }
}
