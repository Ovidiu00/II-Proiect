using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineStore.API.AutoMapper;
using OnlineStore.API.Controllers;
using OnlineStore.API.ViewModels;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OnlineStore.UnitTests.API.CategoryController_Tests
{
    public class CategoriesTests
    {
        private readonly Mock<IMediator> mockMediator;
        private readonly IMapper mapper;

        private readonly CategoryController controller;

        public CategoriesTests()
        {
            mockMediator = new Mock<IMediator>();

            var myProfile = new AutoMapperApiProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapper = new Mapper(configuration);

            controller = new CategoryController(mockMediator.Object, mapper);

        }
        [Fact]
        public async Task Categories_ExceptionIsThrown_Returns500Status()
        {
            // Arrange

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetCategoriesQuery>(), It.IsAny<CancellationToken>()))
                .Throws(new Exception());


            //// Act
            var actionResult = await controller.Categories();
            var result = actionResult.Result as StatusCodeResult;

            //// Assert
            int expectedStatusCode = 500;
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }
        [Fact]
        public async Task Categories_QueryReturnsCollectionOfDTO_ReturnsCollectionOfCategoryVM()
        {
            // Arrange
            var categories = new List<CategoryDTO>();

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetCategoriesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(categories);


            //// Act
            var actionResult = await controller.Categories();
            var result = actionResult.Result as OkObjectResult;

            var actualCategories = (IEnumerable<CategoryVM>)result.Value;

            //// Assert

            Assert.IsAssignableFrom<IEnumerable<CategoryVM>>(actualCategories);
        }
        [Fact]
        public async Task Categories_QueryReturnsNull_ReturnsEmptyList()
        {
            // Arrange

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetCategoriesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((IEnumerable<CategoryDTO>)null);

            //// Act
            var actionResult = await controller.Categories();
            var result = actionResult.Result as OkObjectResult;
            var actualCategories = (IEnumerable<CategoryVM>)result.Value;

            //// Assert

            int expectedCount = 0;
            Assert.Equal(expectedCount, actualCategories.Count());
        }
        [Fact]
        public async Task Categories_QueryReturnsEmptyList_ReturnsEmptyList()
        {
            // Arrange


            var products = new List<CategoryDTO>();

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetCategoriesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(null as IEnumerable<CategoryDTO>);


            //// Act
            var actionResult = await controller.Categories();
            var result = actionResult.Result as OkObjectResult;
            var actualCategories = (IEnumerable<CategoryVM>)result.Value;

            //// Assert
            int expectedCount = 0;
            Assert.Equal(expectedCount, actualCategories.Count());
        }
        [Fact]
        public async Task PopularProducts_WhenExecuted_Returns200StatusCode()
        {
            // Arrange


            var categories = new List<CategoryDTO>();

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetCategoriesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(categories);


            //// Act
            var actionResult = await controller.Categories();
            var result = actionResult.Result as OkObjectResult;
            

            //// Assert
            int expectedStatusCode = 200;
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }
        [Fact]
        public async Task PopularProducts_WhenExecuted_CallsMediatorOnce()
        {
            // Arrange


            var products = new List<CategoryDTO>();

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetCategoriesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(null as IEnumerable<CategoryDTO>);


            //// Act
            var actionResult = await controller.Categories();


            //// Assert

            mockMediator.Verify(x => x.Send(It.IsAny<GetCategoriesQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
