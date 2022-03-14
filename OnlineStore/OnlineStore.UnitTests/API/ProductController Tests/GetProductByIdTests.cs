using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineStore.API.AutoMapper;
using OnlineStore.API.Controllers;
using OnlineStore.API.ViewModels;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OnlineStore.UnitTests.API.ProductController_Tests
{
    public class GetProductByIdTests
    {
        private readonly Mock<IMediator> mockMediator;
        private readonly IMapper mapper;

        private readonly ProductsController controller;

        public GetProductByIdTests()
        {
            mockMediator = new Mock<IMediator>();

            var myProfile = new AutoMapperApiProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapper = new Mapper(configuration);

            controller = new ProductsController(mockMediator.Object, mapper);
        }



        [Fact]
        public async Task GetProductById_IdIs0_ReturnsBadRequest()
        {
            // Arrange

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ProductDTO());


            //// Act
            var actionResult = await controller.GetProductById(0);
            var result = actionResult.Result as StatusCodeResult;

            //// Assert
            int expectedStatusCode = 400;
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }
        [Fact]
        public async Task GetProductById_IdIsMinus1_ReturnsBadRequest()
        {
            // Arrange

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ProductDTO());


            //// Act
            var actionResult = await controller.GetProductById(-1);
            var result = actionResult.Result as StatusCodeResult;

            //// Assert
            int expectedStatusCode = 400;
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }
        [Fact]
        public async Task GetProductById_IdIsValid_ReturnsOkStatusCode200()
        {
            // Arrange

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ProductDTO());


            //// Act
            var actionResult = await controller.GetProductById(1);
            var result = actionResult.Result as OkObjectResult;

            //// Assert
            int expectedStatusCode = 200;
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }

        [Fact]
        public async Task GetProductById_QueryReturnsNull_ReturnsNotFound()
        {
            // Arrange

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(null as ProductDTO);


            //// Act
            var actionResult = await controller.GetProductById(1);
            var result = actionResult.Result as StatusCodeResult;



            //// Assert
            int expectedStatusCode = 404;
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }
        [Fact]
        public async Task GetProductById_QueryReturnsCorrectProduct_ProductReturnedByEndpointEqualsProductReturnedByQuery()
        {
            // Arrange
            var productReturned = new ProductDTO()
            {
                Id = 1,
                Name = "A1"
            };
            mockMediator.Setup(repo => repo.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(productReturned);


            //// Act
            var actionResult = await controller.GetProductById(1);
            var result = actionResult.Result as OkObjectResult;
            var productWithGivenId = (ProductVM)result.Value;


            //// Assert
            Assert.Equal(productReturned.Name, productWithGivenId.Name);
        }

        [Fact]
        public async Task GetProductById_QueryReturnsDTO_ReturnsVM()
        {
            // Arrange
            var productReturned = new ProductDTO()
            {
                Id = 1,
                Name = "A1"
            };
            mockMediator.Setup(repo => repo.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(productReturned);


            //// Act
            var actionResult = await controller.GetProductById(1);
            var result = actionResult.Result as OkObjectResult;
            var productWithGivenId = (ProductVM)result.Value;


            //// Assert
            Assert.IsAssignableFrom<ProductVM>(productWithGivenId);
        }

        [Fact]
        public async Task GetProductById_AllIsValid_Returns200StatusCode()
        {
            // Arrange
            var productReturned = new ProductDTO()
            {
                Id = 1,
                Name = "A1"
            };
            mockMediator.Setup(repo => repo.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(productReturned);


            //// Act
            var actionResult = await controller.GetProductById(1);
            var result = actionResult.Result as OkObjectResult;



            //// Assert
            int expectedStatusCode = 200;
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }
    }
}
