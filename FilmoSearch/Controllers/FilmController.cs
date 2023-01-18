using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmoSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;
        //ILogger<FilmController> _logger;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
            //_logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<FilmModel>> Get(CancellationToken cancellationToken)
        {
            return await _filmService.Get(cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<FilmModel> Get(int id, CancellationToken cancellationToken)
        {
            return await _filmService.Get(id, cancellationToken);
        }

        [HttpPost]
        public async Task<FilmModel> Create(FilmModel filmModel, CancellationToken cancellationToken)
        {
            return await _filmService.Create(filmModel, cancellationToken);
        }

        [HttpPut]
        public async Task<FilmModel> Update(FilmModel filmModel, CancellationToken cancellationToken)
        {
            return await _filmService.Update(filmModel, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _filmService.Delete(id, cancellationToken);
        }
    }
}
