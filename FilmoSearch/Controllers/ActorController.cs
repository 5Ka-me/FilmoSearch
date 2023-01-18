using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FilmoSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        //private readonly ILogger<ActorController> _logger;
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
            //_logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<ActorModel>> Get(CancellationToken cancellationToken)
        {
            return await _actorService.Get(cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<ActorModel> Get(int id, CancellationToken cancellationToken)
        {
            return await _actorService.Get(id, cancellationToken);
        }

        [HttpPost]
        public async Task<ActorModel> Create(ActorModel actorModel, CancellationToken cancellationToken)
        {
            return await _actorService.Create(actorModel, cancellationToken);
        }

        [HttpPut]
        public async Task<ActorModel> Update(ActorModel actorModel, CancellationToken cancellationToken)
        {
            return await _actorService.Update(actorModel, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _actorService.Delete(id, cancellationToken);
        }
    }
}
