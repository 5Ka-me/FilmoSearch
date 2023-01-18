using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IActorFilmRepository
    {
        Task<ActorFilm> Get(int ActorId, int FilmId, CancellationToken cancellationToken);
        Task Create(ActorFilm actorFilm, CancellationToken cancellationToken);
        Task Delete(ActorFilm actorFilm, CancellationToken cancellationToken);
    }
}
