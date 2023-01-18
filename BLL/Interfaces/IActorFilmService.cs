namespace BLL.Interfaces
{
    public interface IActorFilmService
    {
        Task Create(int filmId, int actorId, CancellationToken cancellationToken);
        Task Delete(int filmId, int actorId, CancellationToken cancellationToken);
    }
}
