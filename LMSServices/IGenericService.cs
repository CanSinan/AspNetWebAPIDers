namespace LMSServices
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> InsertAsnyc(T entity);
        Task<T> UpdateAsnyc(T entity);
        Task<T> DeleteAsync(int id);

    }
}
