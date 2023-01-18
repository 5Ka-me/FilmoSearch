using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FilmoSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        //private readonly ILogger<ReviewController> _logger;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
            //_logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<ReviewModel>> Get(CancellationToken cancellationToken)
        {
            return await _reviewService.Get(cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<ReviewModel> Get(int id, CancellationToken cancellationToken)
        {
            return await _reviewService.Get(id, cancellationToken);
        }

        [HttpPost]
        public async Task<ReviewModel> Create(ReviewModel reviewModel, CancellationToken cancellationToken)
        {
            return await _reviewService.Create(reviewModel, cancellationToken);
        }

        [HttpPut]
        public async Task<ReviewModel> Update(ReviewModel reviewModel, CancellationToken cancellationToken)
        {
            return await _reviewService.Update(reviewModel, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _reviewService.Delete(id, cancellationToken);
        }
    }
}
