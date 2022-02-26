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
    public class PopularProductsTests
    {
        private readonly Mock<IMediator> mockMediator;
        private readonly IMapper mapper;

        private readonly ProductsController controller;
        public PopularProductsTests()
        {

            mockMediator = new Mock<IMediator>();

            var myProfile = new AutoMapperApiProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapper = new Mapper(configuration);

            controller = new ProductsController(mockMediator.Object, mapper);
        }

        [Fact]
        public async Task PopularProducts_ExceptionIsThrown_Returns500Status()
        {
            // Arrange
        
            mockMediator.Setup(repo => repo.Send(It.IsAny<GetPopularProductsQuery>(), It.IsAny<CancellationToken>()))
                .Throws(new Exception());


            //// Act
            var actionResult = await controller.PopularProducts(It.IsAny<int>());
            var result = actionResult.Result as StatusCodeResult;

            //// Assert
            int expectedStatusCode = 500;
            Assert.Equal(expectedStatusCode,result.StatusCode);
        }
        [Fact]
        public async Task PopularProducts_NrOfProductsIs3AndQueryReturnsCollectionOf3_ReturnsCollectionOf3()
        {
            // Arrange
            int nrOfProducts = 3;
            var products = new List<ProductDTO>()
            {
                new ProductDTO(){Id = 1,Name="Product1",Price = 10,Quantity=1},
                new ProductDTO(){Id = 2,Name="Product2",Price = 20,Quantity=2},
                new ProductDTO(){Id = 3,Name="Product3",Price = 15,Quantity=6},

            };
            mockMediator.Setup(repo => repo.Send(It.IsAny<GetPopularProductsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(products);


            //// Act
            var actionResult = await controller.PopularProducts(nrOfProducts);
            var result = actionResult.Result as OkObjectResult;

            var actualPopularProducts = (IEnumerable<PopularProductVM>)result.Value;

            //// Assert
            int expectedCount = 3;
            Assert.Equal(expectedCount, actualPopularProducts.Count());
        }    
        [Fact]
        public async Task PopularProducts_NrOfProductsIs0AndQueryReturnsEmptyList_ReturnsEmptyCollection()
        {
            // Arrange
            int nrOfProducts = 0;
            var products = new List<ProductDTO>();

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetPopularProductsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(products);



            //// Act
            var actionResult = await controller.PopularProducts(nrOfProducts);
            var result = actionResult.Result as OkObjectResult;

            var actualPopularProducts = (IEnumerable<PopularProductVM>)result.Value;

            //// Assert
            int expectedCount = 0;
            Assert.Equal(expectedCount, actualPopularProducts.Count());
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        [InlineData(-5)]
        [InlineData(-6)]
        [InlineData(-7)]
        [InlineData(-8)]
        [InlineData(-9)]
        [InlineData(-10)]
        public async Task PopularProducts_NrOfProductsIsNegativeNumberAndQueryReturnsEmptyCollection_ReturnsEmptyCollection(int negativeNrOfProducts)
        {
            // Arrange
            var products = new List<ProductDTO>();

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetPopularProductsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(products);



            //// Act
            var actionResult = await controller.PopularProducts(negativeNrOfProducts);
            var result = actionResult.Result as OkObjectResult;

            var actualPopularProducts = (IEnumerable<PopularProductVM>)result.Value;

            //// Assert
            int expectedCount = 0;
            Assert.Equal(expectedCount, actualPopularProducts.Count());
        }     
        [Fact]
        public async Task PopularProducts_QueryReturnsCollectionOfDTO_ReturnsCollectionOfPopularProductsVM()
        {
            // Arrange
            var products = new List<ProductDTO>();

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetPopularProductsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(products);


            //// Act
            var actionResult = await controller.PopularProducts(It.IsAny<int>());
            var result = actionResult.Result as OkObjectResult;

            var actualPopularProducts = (IEnumerable<PopularProductVM>)result.Value;

            //// Assert

            Assert.IsAssignableFrom<IEnumerable<PopularProductVM>>(actualPopularProducts);
        }     
        [Fact]
        public async Task PopularProducts_QueryReturnsNull_ReturnsEmptyList()
        {
            // Arrange

            mockMediator.Setup(repo => repo.Send(It.IsAny<GetPopularProductsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((IEnumerable<ProductDTO>)null);


            //// Act
            var actionResult = await controller.PopularProducts(It.IsAny<int>());
            var result = actionResult.Result as OkObjectResult;
            var actualPopularProducts = (IEnumerable<PopularProductVM>)result.Value;

            //// Assert

            int expectedCount = 0;
            Assert.Equal(expectedCount, actualPopularProducts.Count());
        }   
        [Fact]
        public async Task PopularProducts_QueryReturnsEmptyList_ReturnsEmptyList()
        {
            // Arrange
            var products = new List<ProductDTO>();
        
            mockMediator.Setup(repo => repo.Send(It.IsAny<GetPopularProductsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((IEnumerable<ProductDTO>)null);


            //// Act
            var actionResult = await controller.PopularProducts(It.IsAny<int>());
            var result = actionResult.Result as OkObjectResult;
            var actualPopularProducts = (IEnumerable<PopularProductVM>)result.Value;

            //// Assert
            int expectedCount = 0;
            Assert.Equal(expectedCount, actualPopularProducts.Count());
        }    
    }
}
