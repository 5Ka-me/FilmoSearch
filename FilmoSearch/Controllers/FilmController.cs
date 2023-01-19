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

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _filmService.GetAll(cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _filmService.GetById(id, cancellationToken);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FilmModel filmModel, CancellationToken cancellationToken)
        {
            var result = await _filmService.Create(filmModel, cancellationToken);

            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(FilmModel filmModel, CancellationToken cancellationToken)
        {
            var result = await _filmService.Update(filmModel, cancellationToken);

            return Accepted(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _filmService.Delete(id, cancellationToken);

            return NoContent();
        }
    }
}
