namespace EffectCert.BLL
{
    public interface ICommonBLL<T> where T : class
    {
        Task<T> Get(int id);
        Task<int> UpdateOrCreate(T entity);
        Task<ICollection<T>> Find(string searchStr);
    }
}
