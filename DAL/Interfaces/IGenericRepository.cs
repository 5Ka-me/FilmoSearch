namespace DAL.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);
        Task<T?> GetById(int id, CancellationToken cancellationToken);
        Task<T> Create(T entity, CancellationToken cancellationToken);
        Task<T> Update(T entity, CancellationToken cancellationToken);
        Task Delete(T entity, CancellationToken cancellationToken);
    }
}
