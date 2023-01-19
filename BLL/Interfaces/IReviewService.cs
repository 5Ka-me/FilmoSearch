using BLL.Models;

namespace BLL.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewModel>> GetAll(CancellationToken cancellationToken);
        Task<ReviewModel> GetById(int id, CancellationToken cancellationToken);
        Task<ReviewModel> Create(ReviewModel review, CancellationToken cancellationToken);
        Task<ReviewModel> Update(ReviewModel review, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}
