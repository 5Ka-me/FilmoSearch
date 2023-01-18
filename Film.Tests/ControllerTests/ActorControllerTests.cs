using BLL.Interfaces;
using BLL.Models;
using FilmoSearch.Controllers;
using Moq;
using Xunit;

namespace Films.Tests.ControllerTests
{
    public class ActorControllerTests
    {
        private readonly Mock<IActorService> _service = new();
        private readonly Mock<CancellationTokenSource> _cancellationTokenSource = new();

        [Fact]
        public void GetAllActors()
        {
            //Arrange
            _service.Setup(x => x.Get(_cancellationTokenSource.Object.Token).Result).Returns(GetListOfActors());

            var controller = new ActorController(_service.Object);
            const int expected = 2;

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

            var controller = new ActorController(_service.Object);

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

            var controller = new ActorController(_service.Object);

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

            var controller = new ActorController(_service.Object);

            //Act
            var result = controller.Get(idSample, _cancellationTokenSource.Object.Token).Result;

            //Assert
            Assert.NotNull(result);
            Assert.True(model.Equals(result));
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
