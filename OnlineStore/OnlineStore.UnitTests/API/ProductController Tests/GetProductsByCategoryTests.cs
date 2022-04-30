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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OnlineStore.UnitTests.API.ProductController_Tests
{
    public class GetProductsByCategoryTests
    {
        private readonly Mock<IMediator> mockMediator;
        private readonly IMapper mapper;

        private readonly ProductsController controller;

        public GetProductsByCategoryTests()
        {
            mockMediator = new Mock<IMediator>();

            var myProfile = new AutoMapperApiProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapper = new Mapper(configuration);

            controller = new ProductsController(mockMediator.Object, mapper);
        }
        [Fact]
        public async Task GetProductsByCategory_IdIs0_ReturnsBadRequest()
        {
            // Arrange

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetProductsByCategoryQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ProductDTO>());


            //// Act
            var actionResult = await controller.GetProductsByCategory(0);
            var result = actionResult.Result as StatusCodeResult;

            //// Assert
            int expectedStatusCode = 400;
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }
        [Fact]
        public async Task GetProductsByCategory_IdIsMinus1_ReturnsBadRequest()
        {
            // Arrange

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetProductsByCategoryQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ProductDTO>());


            //// Act
            var actionResult = await controller.GetProductsByCategory(-1);
            var result = actionResult.Result as StatusCodeResult;

            //// Assert
            int expectedStatusCode = 400;
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }
        [Fact]
        public async Task GetProductsByCategory_IdIsValid_ReturnsStatusCode200()
        {
            // Arrange

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetProductsByCategoryQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ProductDTO>());


            //// Act
            var actionResult = await controller.GetProductsByCategory(1);
            var result = actionResult.Result as OkObjectResult;

            //// Assert
            int expectedStatusCode = 200;
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }
        [Fact]
        public async Task GetProductsByCategory_QueryReturnsNull_ReturnsNotFound()
        {
            // Arrange

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetProductsByCategoryQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(null as IEnumerable<ProductDTO>);


            //// Act
            var actionResult = await controller.GetProductsByCategory(1);
            var result = actionResult.Result as StatusCodeResult;



            //// Assert
            int expectedStatusCode = 404;
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }
        [Fact]
        public async Task GetProductsByCategory_QueryReturnsCorrectProducts_ProductsReturnedByEndpointEqualsProductsReturnedByQuery()
        {
            // Arrange
            var productsReturned = new List<ProductDTO>()
            {
                new ProductDTO()
                {
                    Id = 1,
                    Name = "P1"
                },
                new ProductDTO()
                {
                    Id = 2,
                    Name = "P2"
                }
            };
            mockMediator.Setup(repo => repo.Send(It.IsAny<GetProductsByCategoryQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(productsReturned);


            //// Act
            var actionResult = await controller.GetProductsByCategory(1);
            var result = actionResult.Result as OkObjectResult;
            var productWithGivenCategoryId = (List<ProductVM>)result.Value;


            //// Assert
            Assert.Equal(productsReturned.ElementAt(0).Name, productWithGivenCategoryId.ElementAt(0).Name);
        }
        [Fact]
        public async Task GetProductsByCategory_QueryReturnsDTOList_ReturnsVMList()
        {
            // Arrange
            var productsReturned = new List<ProductDTO>()
            {
                new ProductDTO()
                {
                    Id = 1,
                    Name = "P1"
                },
                new ProductDTO()
                {
                    Id = 2,
                    Name = "P2"
                }
            };
            mockMediator.Setup(repo => repo.Send(It.IsAny<GetProductsByCategoryQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(productsReturned);


            //// Act
            var actionResult = await controller.GetProductsByCategory(1);
            var result = actionResult.Result as OkObjectResult;
            var productWithGivenCategoryId = (List<ProductVM>)result.Value;


            //// Assert
            Assert.IsAssignableFrom<List<ProductVM>>(productWithGivenCategoryId);
        }
        [Fact]
        public async Task GetProductsByCategory_AllIsValid_Returns200StatusCode()
        {
            // Arrange
            var productsReturned = new List<ProductDTO>()
            {
                new ProductDTO()
                {
                    Id = 1,
                    Name = "P1"
                },
                new ProductDTO()
                {
                    Id = 2,
                    Name = "P2"
                }
            };
            mockMediator.Setup(repo => repo.Send(It.IsAny<GetProductsByCategoryQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(productsReturned);


            //// Act
            var actionResult = await controller.GetProductsByCategory(1);
            var result = actionResult.Result as OkObjectResult;


            //// Assert
            int expectedStatusCode = 200;
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }
    }
}
