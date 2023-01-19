using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmoSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _reviewService.GetAll(cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _reviewService.GetById(id, cancellationToken);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReviewModel reviewModel, CancellationToken cancellationToken)
        {
            var result = await _reviewService.Create(reviewModel, cancellationToken);

            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ReviewModel reviewModel, CancellationToken cancellationToken)
        {
            var result = await _reviewService.Update(reviewModel, cancellationToken);

            return Accepted(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _reviewService.Delete(id, cancellationToken);

            return NoContent();
        }
    }
}
