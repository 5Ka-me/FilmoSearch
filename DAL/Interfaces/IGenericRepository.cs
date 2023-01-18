namespace DAL.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> Get(CancellationToken cancellationToken);
        Task<T> Get(int id, CancellationToken cancellationToken);
        Task<T> Create(T entity, CancellationToken cancellationToken);
        Task<T> Update(T entity, CancellationToken cancellationToken);
        Task Delete(T entity, CancellationToken cancellationToken);
    }
}
