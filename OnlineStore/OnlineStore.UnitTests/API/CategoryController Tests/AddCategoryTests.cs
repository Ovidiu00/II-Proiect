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
    public class AddCategoryTests
    {
        private readonly Mock<IMediator> mockMediator;
        private readonly IMapper mapper;

        private readonly CategoryController controller;

        public AddCategoryTests()
        {
            mockMediator = new Mock<IMediator>();

            var myProfile = new AutoMapperApiProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapper = new Mapper(configuration);

            controller = new CategoryController(mockMediator.Object, mapper);
        }

        [Fact]
        public async Task AddCategory_AddCategoryVMIsNull_ReturnsBadRequest()
        {
            //// Act
            var actionResult = await controller.AddCategory(null);

            //// Assert
            Assert.IsType<BadRequestResult>(actionResult);
        }
        [Fact]
        public async Task AddCategory_AllIsValid_ReturnsCreatedAtAction()
        {
            ///Arange 
            mockMediator.Setup(repo => repo.Send(It.IsAny<AddCategoryCommand>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(new CategoryDTO());
            //// Act
            var actionResult = await controller.AddCategory(new AddCategoryVM());

            //// Assert
            Assert.IsType<CreatedAtActionResult>(actionResult);
        }
        [Fact]
        public async Task AddCategory_CategoryToBeAddedIsValid_ReturnedResponseContainsActionMethodForGet()
        {
            // Arrange
            var categoryToBeAdded = new AddCategoryVM()
            {
                Name = "articole barbati"
            };
            var categoryReturnedByMediator = new CategoryDTO()
            {
                Id = 1,
                Name = "articole barbati"
            };
            mockMediator.Setup(repo => repo.Send(It.IsAny<AddCategoryCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(categoryReturnedByMediator);

            //// Act
            var actionResult = await controller.AddCategory(categoryToBeAdded);
            var result = actionResult as CreatedAtActionResult;

            Assert.Equal(nameof(controller.GetCategoryById), result.ActionName);
        }
        [Fact]
        public async Task AddCategory_AllIsValid_AddCategoryCommandCalledOnce()
        {
            // Arrange
            mockMediator.Setup(repo => repo.Send(It.IsAny<AddCategoryCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CategoryDTO());

            //// Act
            var actionResult = await controller.AddCategory(new AddCategoryVM());

            //// Assert
            mockMediator.Verify(x => x.Send(It.IsAny<AddCategoryCommand>(),It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
