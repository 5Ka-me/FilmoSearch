using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class ActorFilmService : IActorFilmService
    {
        private readonly IActorFilmRepository _actorFilmRepository;

        public ActorFilmService(IActorFilmRepository actorFilmRepository)
        {
            _actorFilmRepository = actorFilmRepository;
        }

        public async Task Create(int filmId, int actorId, CancellationToken cancellationToken)
        {
            var actorFilm = new ActorFilm { FilmId = filmId, ActorId = actorId };

            await _actorFilmRepository.Create(actorFilm, cancellationToken);
        }

        public async Task Delete(int filmId, int actorId, CancellationToken cancellationToken)
        {
            var actorFilm = await _actorFilmRepository.GetById(actorId, filmId, cancellationToken);

            await _actorFilmRepository.Delete(actorFilm, cancellationToken);
        }
    }
}
