using BLL.Interfaces;
using BLL.Models;
using FilmoSearch.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Films.Tests.ControllerTests
{
    public class FilmControllerTests
    {
        private readonly Mock<IFilmService> _service = new();
        private readonly Mock<CancellationTokenSource> _cancellationTokenSource = new();

        [Fact]
        public async void GetAllFilms()
        {
            //Arrange
            var listOfFilms = GetListOfFilms();
            _service.Setup(x => x.GetAll(_cancellationTokenSource.Object.Token).Result).Returns(listOfFilms);

            var controller = new FilmController(_service.Object);

            //Act
            var result = await controller.GetAll(_cancellationTokenSource.Object.Token);
            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void DeleteFilm()
        {
            //Arrange
            _service.Setup(x => x.Delete(3, _cancellationTokenSource.Object.Token));

            var controller = new FilmController(_service.Object);

            //Act
            var result = await controller.Delete(3, _cancellationTokenSource.Object.Token);
            var noContentResult = result as NoContentResult;

            //Assert
            Assert.NotNull(noContentResult);
            Assert.Equal(204, noContentResult.StatusCode);
        }

        [Fact]
        public async void CreateFilm()
        {
            //Arrange
            var model = GetModel();

            _service.Setup(x => x.Create(model, _cancellationTokenSource.Object.Token).Result).Returns(model);

            var controller = new FilmController(_service.Object);

            //Act
            var result = await controller.Create(model, _cancellationTokenSource.Object.Token);
            var createdResult = result as CreatedResult;

            //Assert
            Assert.NotNull(createdResult);
            Assert.Equal(201, createdResult.StatusCode);
        }

        [Fact]
        public async void GetFilm()
        {
            //Arrange
            var model = GetModel();
            const int idSample = 3;

            _service.Setup(x => x.GetById(idSample, _cancellationTokenSource.Object.Token).Result).Returns(model);

            var controller = new FilmController(_service.Object);

            //Act
            var result = await controller.GetById(idSample, _cancellationTokenSource.Object.Token);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
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