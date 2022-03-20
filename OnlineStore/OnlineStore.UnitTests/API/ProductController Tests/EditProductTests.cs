//using AutoMapper;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using OnlineStore.API.AutoMapper;
//using OnlineStore.API.Controllers;
//using OnlineStore.Business.DTOs;
//using System.Threading;
//using System.Threading.Tasks;
//using Xunit;

//namespace OnlineStore.UnitTests.API.ProductController_Tests
//{
//    public class EditProductTests
//    {
//        private readonly Mock<IMediator> mockMediator;
//        private readonly IMapper mapper;

//        private readonly ProductsController controller;

//        public EditProductTests()
//        {
//            mockMediator = new Mock<IMediator>();

//            var myProfile = new AutoMapperApiProfile();
//            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
//            mapper = new Mapper(configuration);

//            controller = new ProductsController(mockMediator.Object, mapper);
//        }

//        public Task EditProduct_ProductToBeEdditedIsNull_ReturnsBadRequest400Code()
//        {
//            // Arrange
//            int expectedStatusCode = 400;

//            //// Act
//            var actionResult = await controller.EditProduct(null);
//            var result = actionResult.Result as StatusCodeResult;

//            //// Assert
//            Assert.Equal(expectedStatusCode, result.StatusCode);
//        }
//        public Task EditProduct_ProductToEdditedIsValid_ReturnsNoContent()
//        {
//            // Arrange
//            mockMediator.Setup(repo => repo.Send(It.IsAny<EditProductCommand>(), It.IsAny<CancellationToken>()))
//                .ReturnsAsync(new ProductDTO());

//            //// Act
//            var actionResult = await controller.EditProduct(new EditProductVM());

//            //// Assert
//            Assert.IsType<NoContentResult>(actionResult);
//        }

//        public Task EditProduct_AllIsValid_EditProductCommandIsCalledOnce()
//        {
//            // Arrange
//            mockMediator.Setup(repo => repo.Send(It.IsAny<EditProductCommand>(), It.IsAny<CancellationToken>()))
//                .ReturnsAsync(new ProductDTO());

//            //// Act
//            var actionResult = await controller.EditProduct(new EditProductVM());

//            //// Assert
//            mockMediator.Verify(x => x.Send(It.IsAny<EditProductCommand>), Times.Once);
//            }

//        [Fact]
//        public async Task EditProduct_ExceptionIsThrown_Returns500Status()
//        {
//            // Arrange

//            mockMediator.Setup(repo => repo.Send(It.IsAny<EditProductCommand>(), It.IsAny<CancellationToken>()))
//                .Throws(new Exception("foo"));


//            //// Act
//            var actionResult = await controller.EditCommand(2);
//            var result = actionResult.Result as StatusCodeResult;

//            //// Assert
//            int expectedStatusCode = 500;
//            Assert.Equal(expectedStatusCode, result.StatusCode);
//        }



//    }
//}
