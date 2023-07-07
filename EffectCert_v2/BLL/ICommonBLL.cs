namespace EffectCert.BLL
{
    public interface ICommonBLL<T> where T : class
    {
        Task<T> Get(int id);
        Task<int> UpdateOrCreate(T entity);
        Task<IEnumerable<T>> Find(string searchStr);
    }
}
