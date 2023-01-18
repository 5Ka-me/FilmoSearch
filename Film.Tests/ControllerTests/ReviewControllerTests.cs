using BLL.Interfaces;
using BLL.Models;
using FilmoSearch.Controllers;
using Moq;
using Xunit;

namespace Films.Tests.ControllerTests
{
    public class ReviewControllerTests
    {
        private readonly Mock<IReviewService> _service = new();
        private readonly Mock<CancellationTokenSource> _cancellationTokenSource = new();

        [Fact]
        public void GetAllActors()
        {
            //Arrange
            _service.Setup(x => x.Get(_cancellationTokenSource.Object.Token).Result).Returns(GetListOfActors());

            var controller = new ReviewController(_service.Object);
            const int expected = 3;

            //Act
            var result = controller.Get(_cancellationTokenSource.Object.Token).Result;

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(expected, result.Count());
        }

        [Fact]
        public void DeleteActor()
        {
            //Arrange
            _service.Setup(x => x.Delete(3, _cancellationTokenSource.Object.Token));

            var controller = new ReviewController(_service.Object);

            //Act
            controller.Delete(3, _cancellationTokenSource.Object.Token);

            //Assert
            _service.Verify(x => x.Delete(3, _cancellationTokenSource.Object.Token), Times.Exactly(1));
        }

        [Fact]
        public void CreateActor()
        {
            //Arrange
            var model = GetModel();

            _service.Setup(x => x.Create(model, _cancellationTokenSource.Object.Token).Result).Returns(model);

            var controller = new ReviewController(_service.Object);

            //Act
            var result = controller.Create(model, _cancellationTokenSource.Object.Token).Result;

            //Assert
            Assert.NotNull(result);
            Assert.True(model.Equals(result));
        }

        [Fact]
        public void GetActor()
        {
            //Arrange
            var model = GetModel();
            const int idSample = 3;

            _service.Setup(x => x.Get(idSample, _cancellationTokenSource.Object.Token).Result).Returns(model);

            var controller = new ReviewController(_service.Object);

            //Act
            var result = controller.Get(idSample, _cancellationTokenSource.Object.Token).Result;

            //Assert
            Assert.NotNull(result);
            Assert.True(model.Equals(result));
        }

        private static IEnumerable<ReviewModel> GetListOfActors()
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
