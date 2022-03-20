using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineStore.API.AutoMapper;
using OnlineStore.API.Controllers;
using OnlineStore.API.ViewModels;
using OnlineStore.Business.DTOs;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OnlineStore.UnitTests.API.ProductController_Tests
{
    public class AddProductTests
    {
        private readonly Mock<IMediator> mockMediator;
        private readonly IMapper mapper;

        private readonly ProductsController controller;

        public AddProductTests()
        {
            mockMediator = new Mock<IMediator>();

            var myProfile = new AutoMapperApiProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapper = new Mapper(configuration);

            controller = new ProductsController(mockMediator.Object, mapper);
        }

        public Task AddProduct_ProductToBeAddedIsNull_ReturnsBadRequest400Code()
        {
            // Arrange
            int expectedStatusCode = 400;

            //// Act
            var actionResult = await controller.AddProduct(null);
            var result = actionResult.Result as StatusCodeResult;

            //// Assert
            Assert.Equal(expectedStatusCode, result.StatusCode);
        }
        public Task AddProduct_ProductToBeAddedIsValid_ReturnsCreatedAtActionResult()
        {
            // Arrange
            mockMediator.Setup(repo => repo.Send(It.IsAny<AddProductCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ProductDTO());

            //// Act
            var actionResult = await controller.AddProduct(new AddProductVM());

            //// Assert
            Assert.IsType<CreatedAtActionResult>(actionResult);
        }

        public Task AddProduct_ProductToBeAddedIsValid_ReturnedResponseContainsCreatedItem()
        {
            // Arrange
            var productToBeAdded = new AddProductVM()
            {
                Name = "Paine"
            };
            var productReturnedByMediator = new ProductDTO()
            {
                Name = "Paine"
            };
            mockMediator.Setup(repo => repo.Send(It.IsAny<AddProductCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(productReturnedByMediator);

            //// Act
            var actionResult = await controller.AddProduct(productToBeAdded) as CreatedAtActionResult;
            var product = actionResult.Value as ProductVM;


            // Assert
            Assert.Equal("Paine", product.Name);
        }
        public Task AddProduct_ProductToBeAddedIsValid_ReturnesProductVM()
        {
            // Arrange
            var productToBeAdded = new AddProductVM()
            {
                Name = "Paine"
            };
            var productReturnedByMediator = new ProductDTO()
            {
                Name = "Paine"
            };
            mockMediator.Setup(repo => repo.Send(It.IsAny<AddProductCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(productReturnedByMediator);

            //// Act
            var actionResult = await controller.AddProduct(productToBeAdded) as CreatedAtActionResult;
            var product = actionResult.Value as ProductVM;


            // Assert
            Assert.IsType<ProductVM>(product);
        }

    }
}
