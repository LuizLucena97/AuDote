using AuDote.API.Controllers;
using AuDote.Database.Models;
using AuDote.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace TestProject1
{
    public class CachorrosControllerTests
    {
        private readonly Mock<IRepository<Cachorro>> _mockRepository;
        private readonly CachorrosController _controller;

        public CachorrosControllerTests()
        {
            _mockRepository = new Mock<IRepository<Cachorro>>();
            _controller = new CachorrosController(_mockRepository.Object);
        }

        [Fact]
        public void Post_Should_Return_Created_When_Cachorro_Is_Valid()
        {
            // Arrange
            var cachorro = new Cachorro
            {
                Nome = "Rex",
                Raca = "Pastor Alemão",
                Idade = "3",
                Tamanho = "Grande",
                Peso = 35.0m,
                Sexo = "Macho",
                Castrado = true,
                Vacinado = true,
                StatusAdocao = "Disponível"
            };

            _mockRepository.Setup(repo => repo.Add(cachorro)).Verifiable();

            // Act
            var result = _controller.Post(cachorro) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.Created, result.StatusCode);
            Assert.Equal(cachorro, result.Value);
            _mockRepository.Verify(repo => repo.Add(cachorro), Times.Once);
        }

        [Fact]
        public void Post_Should_Return_BadRequest_When_Cachorro_Is_Null()
        {
            // Act
            var result = _controller.Post(null) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            Assert.Equal("Cachorro não pode ser nulo.", result.Value);
        }

        [Fact]
        public void GetAll_Should_Return_Ok_When_Successful()
        {
            // Arrange
            var cachorros = new List<Cachorro>
            {
                new Cachorro { Nome = "Max", Raca = "Beagle", Idade = "5", Tamanho = "Médio", Peso = 20.0m, Sexo = "Macho", Castrado = true, Vacinado = true, StatusAdocao = "Disponível" }
            };

            _mockRepository.Setup(repo => repo.GetAll()).Returns(cachorros);

            // Act
            var result = _controller.GetAll() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(cachorros, result.Value);
        }

        [Fact]
        public void GetById_Should_Return_Ok_When_Cachorro_Exists()
        {
            // Arrange
            var cachorro = new Cachorro { Nome = "Buddy", Raca = "Golden Retriever", Idade = "4", Tamanho = "Grande", Peso = 30.0m, Sexo = "Macho", Castrado = true, Vacinado = true, StatusAdocao = "Disponível" };
            string id = cachorro.Id.ToString();

            _mockRepository.Setup(repo => repo.GetById(id)).Returns(cachorro);

            // Act
            var result = _controller.GetById(id) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(cachorro, result.Value);
        }

        [Fact]
        public void GetById_Should_Return_NotFound_When_Cachorro_Does_Not_Exist()
        {
            // Arrange
            string id = "invalid_id";
            _mockRepository.Setup(repo => repo.GetById(id)).Returns((Cachorro)null);

            // Act
            var result = _controller.GetById(id) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            Assert.Equal("Cachorro não encontrado.", result.Value);
        }

        [Fact]
        public void Update_Should_Return_NotFound_When_Cachorro_Does_Not_Exist()
        {
            // Arrange
            string id = "invalid_id";
            var cachorro = new Cachorro { Nome = "Buddy", Raca = "Golden Retriever", Idade = "4", Tamanho = "Grande", Peso = 30.0m, Sexo = "Macho", Castrado = true, Vacinado = true, StatusAdocao = "Disponível" };

            _mockRepository.Setup(repo => repo.GetById(id)).Returns((Cachorro)null);

            // Act
            var result = _controller.Update(id, cachorro) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            Assert.Equal("Cachorro não encontrado.", result.Value);
        }

        [Fact]
        public void Update_Should_Return_Ok_When_Cachorro_Exists()
        {
            // Arrange
            var cachorro = new Cachorro { Nome = "Buddy", Raca = "Golden Retriever", Idade = "4", Tamanho = "Grande", Peso = 30.0m, Sexo = "Macho", Castrado = true, Vacinado = true, StatusAdocao = "Disponível" };
            string id = cachorro.Id.ToString();

            _mockRepository.Setup(repo => repo.GetById(id)).Returns(cachorro);
            _mockRepository.Setup(repo => repo.Update(cachorro)).Verifiable();

            // Act
            var result = _controller.Update(id, cachorro) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("Cachorro atualizado com sucesso.", result.Value);
            _mockRepository.Verify(repo => repo.Update(cachorro), Times.Once);
        }

        [Fact]
        public void Delete_Should_Return_Ok_When_Cachorro_Deleted_Successfully()
        {
            // Arrange
            var cachorro = new Cachorro { Nome = "Buddy", Raca = "Golden Retriever", Idade = "4", Tamanho = "Grande", Peso = 30.0m, Sexo = "Macho", Castrado = true, Vacinado = true, StatusAdocao = "Disponível" };
            string id = cachorro.Id.ToString();

            _mockRepository.Setup(repo => repo.GetById(id)).Returns(cachorro);
            _mockRepository.Setup(repo => repo.Delete(cachorro)).Verifiable();

            // Act
            var result = _controller.Delete(id) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("Cachorro deletado com sucesso.", result.Value);
            _mockRepository.Verify(repo => repo.Delete(cachorro), Times.Once);
        }

        [Fact]
        public void Delete_Should_Return_NotFound_When_Cachorro_Does_Not_Exist()
        {
            // Arrange
            string id = "invalid_id";
            _mockRepository.Setup(repo => repo.GetById(id)).Returns((Cachorro)null);

            // Act
            var result = _controller.Delete(id) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            Assert.Equal("Cachorro não encontrado.", result.Value);
        }
    }
}
