namespace EffectCert.BLL.Interfaces
{
    public interface ICommonBLL<T> where T : class
    {
        Task<T> Get(int id);
        Task<int> UpdateOrCreate(T entity);
        Task<ICollection<T>> Find(string searchStr);
        Task<ICollection<T>> FindAll();
        Task<int> Delete(int id);
    }
}
