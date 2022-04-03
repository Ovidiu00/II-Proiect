using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineStore.API.AutoMapper;
using OnlineStore.API.Controllers;
using OnlineStore.API.ViewModels;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.Requests.Commands;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OnlineStore.UnitTests.API.CategoryController_Tests
{
    public class DeleteCategoryTests
    {
        private readonly Mock<IMediator> mockMediator;
        private readonly IMapper mapper;

        private readonly CategoryController controller;

        public DeleteCategoryTests()
        {
            mockMediator = new Mock<IMediator>();

            var myProfile = new AutoMapperApiProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapper = new Mapper(configuration);

            controller = new CategoryController(mockMediator.Object, mapper);
        }

        [Fact]
        public async Task DeleteCategory_IdIs0_ReturnsBadRequest()
        {
            //// Act
            var actionResult = await controller.DeleteCategory( 0);

            //// Assert
            Assert.IsType<BadRequestResult>(actionResult);
        }
        [Fact]
        public async Task DeleteCategory_AllIsValid_ReturnsNoContet()
        {
            ///Arange 
            mockMediator.Setup(repo => repo.Send(It.IsAny<DeleteCategoryCommand>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(true);
            //// Act
            var actionResult = await controller.DeleteCategory(2);

            //// Assert
            Assert.IsType<NoContentResult>(actionResult);
        }
        [Fact]
        public async Task DeleteCategory_DeleteCategoryCommandReturnsFalse_Returns500StatusCode()
        {
            ///Arange 
            mockMediator.Setup(repo => repo.Send(It.IsAny<DeleteCategoryCommand>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(false);
            //// Act
            var actionResult = await controller.DeleteCategory(2);
            var result = actionResult as StatusCodeResult;

            //// Assert
            Assert.Equal(500, result.StatusCode);
        }
        [Fact]
        public async Task DeleteCategory_AllIsValid_EditCategoryCommandCalledOnce()
        {
            // Arrange
            mockMediator.Setup(repo => repo.Send(It.IsAny<DeleteCategoryCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            //// Act
            var actionResult = await controller.DeleteCategory(2);

            //// Assert
            mockMediator.Verify(x => x.Send(It.IsAny<DeleteCategoryCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
