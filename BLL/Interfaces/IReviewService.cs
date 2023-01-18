using BLL.Models;

namespace BLL.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewModel>> Get(CancellationToken cancellationToken);
        Task<ReviewModel> Get(int id, CancellationToken cancellationToken);
        Task<ReviewModel> Create(ReviewModel review, CancellationToken cancellationToken);
        Task<ReviewModel> Update(ReviewModel review, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
