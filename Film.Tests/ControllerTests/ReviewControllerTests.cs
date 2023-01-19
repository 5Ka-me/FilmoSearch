using BLL.Interfaces;
using BLL.Models;
using FilmoSearch.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Films.Tests.ControllerTests
{
    public class ReviewControllerTests
    {
        private readonly Mock<IReviewService> _service = new();
        private readonly Mock<CancellationTokenSource> _cancellationTokenSource = new();

        [Fact]
        public async void GetAllReviews()
        {
            //Arrange
            var listOfActors = GetListOfReviews();
            _service.Setup(x => x.GetAll(_cancellationTokenSource.Object.Token).Result).Returns(listOfActors);

            var controller = new ReviewController(_service.Object);

            //Act
            var result = await controller.GetAll(_cancellationTokenSource.Object.Token);
            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void DeleteReview()
        {
            //Arrange
            _service.Setup(x => x.Delete(3, _cancellationTokenSource.Object.Token));

            var controller = new ReviewController(_service.Object);

            //Act
            var result = await controller.Delete(3, _cancellationTokenSource.Object.Token);
            var noContentResult = result as NoContentResult;

            //Assert
            Assert.NotNull(noContentResult);
            Assert.Equal(204, noContentResult.StatusCode);
        }

        [Fact]
        public async void CreateReview()
        {
            //Arrange
            var model = GetModel();

            _service.Setup(x => x.Create(model, _cancellationTokenSource.Object.Token).Result).Returns(model);

            var controller = new ReviewController(_service.Object);

            //Act
            var result = await controller.Create(model, _cancellationTokenSource.Object.Token);
            var createdResult = result as CreatedResult;

            //Assert
            Assert.NotNull(createdResult);
            Assert.Equal(201, createdResult.StatusCode);
        }

        [Fact]
        public async void GetReview()
        {
            //Arrange
            var model = GetModel();
            const int idSample = 3;

            _service.Setup(x => x.GetById(idSample, _cancellationTokenSource.Object.Token).Result).Returns(model);

            var controller = new ReviewController(_service.Object);

            //Act
            var result = await controller.GetById(idSample, _cancellationTokenSource.Object.Token);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        private static IEnumerable<ReviewModel> GetListOfReviews()
        {
            var list = new List<ReviewModel>()
            {
                new() { Id = 1, Title = "Title 1", Description = "Description 1", Stars=1, FilmId=1},
                new() { Id = 2, Title = "Title 2", Description = "Description 2", Stars=2, FilmId=2},
                new() { Id = 3, Title = "Title 3", Description = "Description 3", Stars=3, FilmId=1},


            };

            return list;
        }

        private static ReviewModel GetModel()
        {
            var model = new ReviewModel()
            {
                Id = 6,
                Title = "Title 11",
                Description = "Decription 11",
                Stars = 5,
                FilmId = 1
            };

            return model;
        }
    }
}
