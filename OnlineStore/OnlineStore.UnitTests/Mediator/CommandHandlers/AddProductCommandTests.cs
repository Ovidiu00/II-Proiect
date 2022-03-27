//using AutoMapper;
//using Moq;
//using OnlineStore.Business.BusinessMapper;
//using OnlineStore.Business.DTOs;
//using OnlineStore.DataAccess.Models.Entities;
//using OnlineStore.DataAccess.Repositories;
//using System;
//using System.Linq.Expressions;
//using System.Threading.Tasks;
//using Xunit;

//namespace OnlineStore.UnitTests.Mediator.CommandHandlers
//{
//    public class AddProductCommandTests
//    {
//        private readonly Mock<IUnitOfWork> mockUnitOfWork;
//        private readonly AddProductCommandHandler handler;

//        public AddProductCommandTests()
//        {
//            var myProfile = new AutoMapperBussinesProfile();
//            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

//            IMapper mapper = new Mapper(configuration);
//            mockUnitOfWork = new Mock<IUnitOfWork>();

//            handler = new AddProductCommandHandler(mockUnitOfWork.Object, mapper);
//        }

//        [Fact]
//        public async Task AddProductCommand_ProductToBeAddedIsNull_ThrowsException()
//        {
//            AddProductCommand query = new AddProductCommand(null,2);

//            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(query, new System.Threading.CancellationToken()));
//        }

//        [Fact]
//        public async Task AddProductCommand_AddToDatabaseThrowsException_ThrowsException()
//        {
//            AddProductCommand query = new AddProductCommand(new AddProductDTO(),2);


//            mockUnitOfWork.Setup(w => w.ProductRepository.Add(It.IsAny<Product>()))
//                .Throws(new Exception());


//            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(query, new System.Threading.CancellationToken()));
//        }

//        [Fact]
//        public async Task AddProductCommand_AllIsValid_ReturnsProductDTO()
//        {
//            AddProductCommand query = new AddProductCommand(new AddProductDTO(),2);


//            var productAdded = await handler.Handle(query, new System.Threading.CancellationToken());



//            Assert.IsAssignableFrom<ProductDTO>(productAdded);
//        }
//        [Fact]
//        public async Task AddProductCommand_CategoryWIthGivenIdCannotBeFound_ReturnsException()
//        {
//            AddProductCommand query = new AddProductCommand(productToBeAdded, 2);
//            mockUnitOfWork.Setup(x => x.CategoryRepository.FindSingle(It.IsAny<Expression<Category,bool>>()))


//        }

//        [Fact]
//        public async Task AddProductCommand_AllIsValid_ReturnsTheSameProductAsTheOneDesiredToBeAdded()
//        {
//            var productToBeAdded = new AddProductDTO()
//            {
//                Name = "P1",
//            };
//            AddProductCommand query = new AddProductCommand(productToBeAdded,2);


//            var productAdded = await handler.Handle(query, new System.Threading.CancellationToken());



//            Assert.IsAssignableFrom<ProductDTO>(productAdded);
//        }

//    }
//}
