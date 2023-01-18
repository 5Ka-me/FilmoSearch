using BLL.Interfaces;
using BLL.Models;
using FilmoSearch.Controllers;
using Moq;
using Xunit;

namespace Films.Tests.ControllerTests
{
    public class FilmControllerTests
    {
        private readonly Mock<IFilmService> _service = new();
        private readonly Mock<CancellationTokenSource> _cancellationTokenSource = new();

        [Fact]
        public void GetAllFilms()
        {
            //Arrange
            _service.Setup(x => x.Get(_cancellationTokenSource.Object.Token).Result).Returns(GetListOfFilms());

            var controller = new FilmController(_service.Object);
            const int expected = 4;

            //Act
            var result = controller.Get(_cancellationTokenSource.Object.Token).Result;

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(expected, result.Count());
        }

        [Fact]
        public void DeleteFilm()
        {
            //Arrange
            _service.Setup(x => x.Delete(3, _cancellationTokenSource.Object.Token));

            var controller = new FilmController(_service.Object);

            //Act
            controller.Delete(3, _cancellationTokenSource.Object.Token);

            //Assert
            _service.Verify(x => x.Delete(3, _cancellationTokenSource.Object.Token), Times.Exactly(1));
        }

        [Fact]
        public void CreateFilm()
        {
            //Arrange
            var model = GetModel();

            _service.Setup(x => x.Create(model, _cancellationTokenSource.Object.Token).Result).Returns(model);

            var controller = new FilmController(_service.Object);

            //Act
            var result = controller.Create(model, _cancellationTokenSource.Object.Token).Result;

            //Assert
            Assert.NotNull(result);
            Assert.True(model.Equals(result));
        }

        [Fact]
        public void GetFilm()
        {
            //Arrange
            var model = GetModel();
            const int idSample = 3;

            _service.Setup(x => x.Get(idSample, _cancellationTokenSource.Object.Token).Result).Returns(model);

            var controller = new FilmController(_service.Object);

            //Act
            var result = controller.Get(idSample, _cancellationTokenSource.Object.Token).Result;

            //Assert
            Assert.NotNull(result);
            Assert.True(model.Equals(result));
        }

        private static IEnumerable<FilmModel> GetListOfFilms()
        {
            var list = new List<FilmModel>()
            {
                new() { Id = 1, Title = "Name 1"},
                new() { Id = 2, Title = "Name 2"},
                new() { Id = 3, Title = "Name 3"},
                new() { Id = 4, Title = "Name 4"}
            };

            return list;
        }

        private static FilmModel GetModel()
        {
            var model = new FilmModel()
            {
                Id = 3,
                Title = "TestTitle"
            };

            return model;
        }
    }
}