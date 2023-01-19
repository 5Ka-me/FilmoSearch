using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IActorFilmRepository
    {
        Task<ActorFilm?> GetById(int actorId, int filmId, CancellationToken cancellationToken);
        Task Create(ActorFilm actorFilm, CancellationToken cancellationToken);
        Task Delete(ActorFilm actorFilm, CancellationToken cancellationToken);
    }
}
