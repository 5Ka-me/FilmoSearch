using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmoSearch.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ActorFilmController : ControllerBase
    {
        private readonly IActorFilmService _actorFilmService;

        public ActorFilmController(IActorFilmService actorFilmService)
        {
            _actorFilmService = actorFilmService;
        }

        [HttpPost("films/{filmId}/actors/{actorId}")]
        public async Task<IActionResult> Create(int filmId, int actorId, CancellationToken cancellationToken)
        {
            await _actorFilmService.Create(filmId, actorId, cancellationToken);

            return Ok();
        }

        [HttpDelete("films/{filmId}/actors/{actorId}")]
        public async Task<IActionResult> Delete(int filmId, int actorId, CancellationToken cancellationToken)
        {
            await _actorFilmService.Delete(filmId, actorId, cancellationToken);

            return NoContent();
        }
    }
}
