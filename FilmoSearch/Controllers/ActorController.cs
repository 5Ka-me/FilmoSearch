using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmoSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _actorService.GetAll(cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _actorService.GetById(id, cancellationToken);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActorModel actorModel, CancellationToken cancellationToken)
        {
            var result = await _actorService.Create(actorModel, cancellationToken);

            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ActorModel actorModel, CancellationToken cancellationToken)
        {
            var result = await _actorService.Update(actorModel, cancellationToken);

            return Accepted(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _actorService.Delete(id, cancellationToken);

            return NoContent();
        }
    }
}
