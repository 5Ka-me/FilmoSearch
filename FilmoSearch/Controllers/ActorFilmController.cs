using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmoSearch.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ActorFilmController : ControllerBase
    {
        //private readonly ILogger<ActorController> _logger;
        private readonly IActorFilmService _actorFilmService;

        public ActorFilmController(IActorFilmService actorFilmService)
        {
            _actorFilmService = actorFilmService;
            //_logger = logger;
        }

        [HttpPost("films/{filmId}/actors/{actorId}")]
        public async Task Create(int filmId, int actorId, CancellationToken cancellationToken)
        {
            await _actorFilmService.Create(filmId, actorId, cancellationToken);
        }

        [HttpDelete("films/{filmId}/actors/{actorId}")]
        public async Task Delete(int filmId, int actorId, CancellationToken cancellationToken)
        {
            await _actorFilmService.Delete(filmId, actorId, cancellationToken);
        }
    }
}
