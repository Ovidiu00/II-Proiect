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

namespace OnlineStore.UnitTests.API.CategoryController_Tests
{
    public class GetCategoryByIdTests
    {
        private readonly Mock<IMediator> mockMediator;
        private readonly IMapper mapper;

        private readonly CategoryController controller;

        public GetCategoryByIdTests()
        {
            mockMediator = new Mock<IMediator>();

            var myProfile = new AutoMapperApiProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapper = new Mapper(configuration);

            controller = new CategoryController(mockMediator.Object, mapper);
        }

        [Fact]
        public async Task GetCategoryById_IdIs0_ReturnsBadRequest()
        {
            // Arrange

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetCategoryByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CategoryDTO());


            //// Act
            var actionResult = await controller.GetCategoryById(0);
            var result = actionResult.Result as StatusCodeResult;

            //// Assert
            int expectedStatusCode = 400;
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }
        [Fact]
        public async Task GetCategoryById_IdIsMinus1_ReturnsBadRequest()
        {
            // Arrange

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetCategoryByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CategoryDTO());


            //// Act
            var actionResult = await controller.GetCategoryById(-1);
            var result = actionResult.Result as StatusCodeResult;

            //// Assert
            int expectedStatusCode = 400;
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }
        [Fact]
        public async Task GetCategoryById_IdIsValid_ReturnsOkStatusCode200()
        {
            // Arrange

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetCategoryByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CategoryDTO());


            //// Act
            var actionResult = await controller.GetCategoryById(It.IsAny<int>());
            var result = actionResult.Result as StatusCodeResult;

            //// Assert
            int expectedStatusCode = 200;
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }

        [Fact]
        public async Task GetCategoryById_QueryReturnsNull_ReturnsNotFound()
        {
            // Arrange

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetCategoryByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(null as CategoryDTO);


            //// Act
            var actionResult = await controller.GetCategoryById(It.IsAny<int>());
            var result = actionResult.Result as StatusCodeResult;



            //// Assert
            int expectedStatusCode = 404;
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }
        [Fact]
        public async Task GetCategoryById_QueryReturnsCorrectCategory_CategoryReturnedByEndpointEqualsCategoryReturnedByQuery()
        {
            // Arrange
            var categoryReturned = new CategoryDTO()
            {
                Id = 1,
                Name = "A1"
            };
            mockMediator.Setup(repo => repo.Send(It.IsAny<GetCategoryByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(categoryReturned);


            //// Act
            var actionResult = await controller.GetCategoryById(It.IsAny<int>());
            var result = actionResult.Result as OkObjectResult;
            var categoryWithGivenId = (CategoryVM)result.Value;


            //// Assert
            Assert.Equal(categoryReturned.Name, categoryWithGivenId.Name);
        }

        [Fact]
        public async Task GetCategoryById_QueryReturnsDTO_ReturnsVM()
        {
            // Arrange
            var categoryReturned = new CategoryDTO()
            {
                Id = 1,
                Name = "A1"
            };
            mockMediator.Setup(repo => repo.Send(It.IsAny<GetCategoryByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(categoryReturned);


            //// Act
            var actionResult = await controller.GetCategoryById(It.IsAny<int>());
            var result = actionResult.Result as OkObjectResult;
            var categoryWithGivenId = (CategoryVM)result.Value;


            //// Assert
            Assert.IsAssignableFrom<CategoryVM>(categoryWithGivenId);
        }

        [Fact]
        public async Task GetCategoryById_AllIsValid_Returns200StatusCode()
        {
            // Arrange
            var categoryReturned = new CategoryDTO()
            {
                Id = 1,
                Name = "A1"
            };
            mockMediator.Setup(repo => repo.Send(It.IsAny<GetCategoryByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(categoryReturned);


            //// Act
            var actionResult = await controller.GetCategoryById(It.IsAny<int>());
            var result = actionResult.Result as StatusCodeResult;



            //// Assert
            int expectedStatusCode = 200;
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }

    }
}
