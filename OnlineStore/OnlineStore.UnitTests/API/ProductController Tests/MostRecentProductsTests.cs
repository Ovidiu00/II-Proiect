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

namespace OnlineStore.UnitTests.API.ProductController_Tests
{
    public class MostRecentProductsTests
    {

        private readonly Mock<IMediator> mockMediator;
        private readonly IMapper mapper;

        private readonly ProductsController controller;
        public MostRecentProductsTests()
        {

            mockMediator = new Mock<IMediator>();

            var myProfile = new AutoMapperApiProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapper = new Mapper(configuration);

            controller = new ProductsController(mockMediator.Object, mapper);
        }
        [Fact]
        public async Task RecentProducts_QueryReturnsCollectionOfDTO_ReturnsCollectionOfRecentProductVM()
        {
            // Arrange
            var products = new List<ProductDTO>();

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetRecentProductsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(products);


            //// Act
            var actionResult = await controller.RecentProducts(It.IsAny<int>());
            var result = actionResult.Result as OkObjectResult;

            var acutalRecentProducts = (IEnumerable<ProductDTO>)result.Value;

            //// Assert

            Assert.IsAssignableFrom<IEnumerable<RecentProductVM>>(acutalRecentProducts);
        }
        [Fact]
        public async Task RecentsProducts_QueryReturnsNull_ReturnsEmptyList()
        {
            // Arrange

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetRecentProductsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((IEnumerable<ProductDTO>)null);


            //// Act
            var actionResult = await controller.RecentProducts(It.IsAny<int>());
            var result = actionResult.Result as OkObjectResult;
            var actualRecentProducts = (IEnumerable<RecentProductVM>)result.Value;

            //// Assert

            int expectedCount = 0;
            Assert.Equal(expectedCount, actualRecentProducts.Count());
        }
        [Fact]
        public async Task RecentsProducts_QueryReturnsEmptyList_ReturnsEmptyList()
        {
            // Arrange
            var products = new List<ProductDTO>();

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetRecentProductsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ProductDTO>());


            //// Act
            var actionResult = await controller.RecentProducts(It.IsAny<int>());
            var result = actionResult.Result as OkObjectResult;
            var actualRecentProducts = (IEnumerable<RecentProductVM>)result.Value;

            //// Assert
            int expectedCount = 0;
            Assert.Equal(expectedCount, actualRecentProducts.Count());
        }


        [Fact]
        public async Task RecentProducts_ExceptionIsThrown_Returns500Status()
        {
            // Arrange

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetRecentProductsQuery>(), It.IsAny<CancellationToken>()))
                .Throws(new Exception());


            //// Act
            var actionResult = await controller.RecentProducts(It.IsAny<int>());
            var result = actionResult.Result as StatusCodeResult;

            //// Assert
            int expectedStatusCode = 500;
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }
        [Fact]
        public async Task RecentProducts_NrOfProductsIs3AndQueryReturnsCollectionOf3_ReturnsCollectionOf3()
        {
            // Arrange
            int nrOfProducts = 3;
            var products = new List<ProductDTO>()
            {
                new ProductDTO(){Id = 1,Name="Product1",Price = 10,Quantity=1},
                new ProductDTO(){Id = 2,Name="Product2",Price = 20,Quantity=2},
                new ProductDTO(){Id = 3,Name="Product3",Price = 15,Quantity=6},

            };
            mockMediator.Setup(repo => repo.Send(It.IsAny<GetRecentProductsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(products);


            //// Act
            var actionResult = await controller.PopularProducts(nrOfProducts);
            var result = actionResult.Result as OkObjectResult;

            var actualRecentProucts = (IEnumerable<RecentProductVM>)result.Value;

            //// Assert
            int expectedCount = 3;
            Assert.Equal(expectedCount, actualRecentProucts.Count());
        }
     
    }
}
