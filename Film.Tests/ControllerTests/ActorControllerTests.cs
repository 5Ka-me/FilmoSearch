using BLL.Interfaces;
using BLL.Models;
using FilmoSearch.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Films.Tests.ControllerTests
{
    public class ActorControllerTests
    {
        private readonly Mock<IActorService> _service = new();
        private readonly Mock<CancellationTokenSource> _cancellationTokenSource = new();

        [Fact]
        public async void GetAllActors()
        {
            //Arrange
            var listOfActors = GetListOfActors();
            _service.Setup(x => x.GetAll(_cancellationTokenSource.Object.Token).Result).Returns(listOfActors);

            var controller = new ActorController(_service.Object);

            //Act
            var result = await controller.GetAll(_cancellationTokenSource.Object.Token);

            // assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async void DeleteActor()
        {
            //Arrange
            _service.Setup(x => x.Delete(3, _cancellationTokenSource.Object.Token));

            var controller = new ActorController(_service.Object);

            //Act
            var result = await controller.Delete(3, _cancellationTokenSource.Object.Token);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(NoContentResult));
        }

        [Fact]
        public async void CreateActor()
        {
            //Arrange
            var model = GetModel();

            _service.Setup(x => x.Create(model, _cancellationTokenSource.Object.Token).Result).Returns(model);

            var controller = new ActorController(_service.Object);

            //Act
            var result = await controller.Create(model, _cancellationTokenSource.Object.Token);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(CreatedResult));
        }

        [Fact]
        public async void GetActor()
        {
            //Arrange
            var model = GetModel();
            const int idSample = 5;

            _service.Setup(x => x.GetById(idSample, _cancellationTokenSource.Object.Token).Result).Returns(model);

            var controller = new ActorController(_service.Object);

            //Act
            var result = await controller.GetById(idSample, _cancellationTokenSource.Object.Token);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        private static IEnumerable<ActorModel> GetListOfActors()
        {
            var list = new List<ActorModel>()
            {
                new() { Id = 1, FirstName = "FirstName", LastName = "LastName"},
                new() { Id = 2, FirstName = "FirstNamee", LastName = "LastNameee"},
            };

            return list;
        }

        private static ActorModel GetModel()
        {
            var model = new ActorModel()
            {
                Id = 5,
                FirstName = "Firstt",
                LastName = "Lastt"
            };

            return model;
        }
    }
}
