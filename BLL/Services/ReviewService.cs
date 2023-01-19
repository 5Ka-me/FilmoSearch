using AutoMapper;
using BLL.Exceptions;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using FluentValidation;

namespace BLL.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<ReviewModel> _validator;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper, IValidator<ReviewModel> validator)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ReviewModel> Create(ReviewModel reviewModel, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(reviewModel, cancellationToken);

            var review = _mapper.Map<Review>(reviewModel);

            await _reviewRepository.Create(review, cancellationToken);

            return reviewModel;
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.GetById(id, cancellationToken);

            if (review == null)
            {
                throw new EntityNotFoundException($"Review with Id: {id} not found");
            }

            await _reviewRepository.Delete(review, cancellationToken);
        }

        public async Task<IEnumerable<ReviewModel>> GetAll(CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.GetAll(cancellationToken);

            return _mapper.Map<IEnumerable<ReviewModel>>(review);
        }

        public async Task<ReviewModel> GetById(int id, CancellationToken cancellationToken)
        {
            var review = await _reviewRepository.GetById(id, cancellationToken);

            if (review == null)
            {
                throw new EntityNotFoundException("Entity review not found");
            }

            return _mapper.Map<ReviewModel>(review);
        }

        public async Task<ReviewModel> Update(ReviewModel reviewModel, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(reviewModel, cancellationToken);

            var review = await _reviewRepository.GetById(reviewModel.Id, cancellationToken);

            if (review == null)
            {
                throw new EntityNotFoundException("Entity review not found");
            }

            _mapper.Map(reviewModel, review);

            await _reviewRepository.Update(review, cancellationToken);

            return reviewModel;
        }
    }
}
