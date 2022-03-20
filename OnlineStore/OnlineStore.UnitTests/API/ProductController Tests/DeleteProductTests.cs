//using AutoMapper;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using OnlineStore.API.AutoMapper;
//using OnlineStore.API.Controllers;
//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using Xunit;

//namespace OnlineStore.UnitTests.API.ProductController_Tests
//{
//    public class DeleteProductTests
//    {
//        private readonly Mock<IMediator> mockMediator;
//        private readonly IMapper mapper;

//        private readonly ProductsController controller;

//        public DeleteProductTests()
//        {
//            mockMediator = new Mock<IMediator>();

//            var myProfile = new AutoMapperApiProfile();
//            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
//            mapper = new Mapper(configuration);

//            controller = new ProductsController(mockMediator.Object, mapper);
//        }

//        public Task DeleteProduct_ExceptionHappensInBussiness_Returns500StatusCode()
//        {
//            // Arrange
//            int expectedStatusCode = 500;
//            mockMediator.Setup(repo => repo.Send(It.IsAny<DeleteProductCommand>(), It.IsAny<CancellationToken>()))
//               .ThrowsAsync(new Exception("foo"));

//            //// Act
//            var actionResult = await controller.DeleteProduct(2);
//            var result = actionResult.Result as StatusCodeResult;

//            //// Assert
//            Assert.Equal(expectedStatusCode, result.StatusCode);
//        }
//        public Task DeleteProduct_IdIs0_ReturnsBadRequest()
//        {
//            // Arrange
//            int expectedStatusCode = 400;

//            //// Act
//            var actionResult = await controller.DeleteProduct(0);
//            var result = actionResult.Result as StatusCodeResult;

//            //// Assert
//            Assert.Equal(expectedStatusCode, result.StatusCode);
//        }
//        public Task DeleteProduct_IdIsMinus1_ReturnsBadRequest()
//        {
//            // Arrange
//            int expectedStatusCode = 400;

//            //// Act
//            var actionResult = await controller.DeleteProduct(-1);
//            var result = actionResult.Result as StatusCodeResult;

//            //// Assert
//            Assert.Equal(expectedStatusCode, result.StatusCode);
//        }

//        public Task DeleteProduct_AllIsValid_ReturnsNoContentResult ()
//        {

//            var actionResult = await controller.DeleteProduct(2);

//            Assert.IsType<NoContentResult>(actionResult);
//        }
//        [Fact]
//        public async Task DeleteProduct_AllIsValid_DeleteProductCommandCalledOnce()
//        {
//            // Arrange

//            mockMediator.Setup(repo => repo.Send(It.IsAny<DeleteProductCommand>(), It.IsAny<CancellationToken>()))


//            //// Act
//            var actionResult = await controller.DeleteProduct(2);

//            //// Assert

//            mockMediator.Verify(x => x.Send(It.IsAny<DeleteProductCommand>()), Times.Once);
//        }

//    }
//}
