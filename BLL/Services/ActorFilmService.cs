using BLL.Exceptions;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class ActorFilmService : IActorFilmService
    {
        private readonly IActorFilmRepository _actorFilmRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IFilmRepository _filmRepository;

        public ActorFilmService(IActorFilmRepository actorFilmRepository, IActorRepository actorRepository, IFilmRepository filmRepository)
        {
            _actorFilmRepository = actorFilmRepository;
            _actorRepository = actorRepository;
            _filmRepository = filmRepository;
        }

        public async Task Create(int filmId, int actorId, CancellationToken cancellationToken)
        {
            var actorFilm = new ActorFilm { FilmId = filmId, ActorId = actorId };

            await ValidatePreConditions(filmId, actorId, cancellationToken);

            var actorFilmTemp = await _actorFilmRepository.GetById(actorId, filmId, cancellationToken);

            if (actorFilmTemp != null)
            {
                throw new EntityAlreadyExistException($"Actor with Id: {actorId} is already taking a part in a film with Id: {filmId}");
            }

            await _actorFilmRepository.Create(actorFilm, cancellationToken);
        }

        public async Task Delete(int filmId, int actorId, CancellationToken cancellationToken)
        {
            var actorFilm = await _actorFilmRepository.GetById(actorId, filmId, cancellationToken);

            await ValidatePreConditions(filmId, actorId, cancellationToken);

            if (actorFilm == null)
            {
                throw new EntityNotFoundException($"Actor with Id: {actorId} in film with Id: {filmId} not found");
            }

            await _actorFilmRepository.Delete(actorFilm, cancellationToken);
        }

        private async Task ValidatePreConditions(int filmId, int actorId, CancellationToken cancellationToken)
        {
            var actor = await _actorRepository.GetById(actorId, cancellationToken);
            var film = await _filmRepository.GetById(filmId, cancellationToken);

            if (actor == null)
            {
                throw new EntityNotFoundException($"Actor with Id: {actorId} not found");
            }

            if (film == null)
            {
                throw new EntityNotFoundException($"Film with Id: {filmId} not found");
            }
        }
    }
}
