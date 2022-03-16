using AutoMapper;
using Moq;
using OnlineStore.Business.BusinessMapper;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.Handlers.QueryHandlers;
using OnlineStore.Business.Mediator.Requests.Queries;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace OnlineStore.UnitTests.Mediator.QueryHandlers
{
    public class GetProductByIdHandlerTests
    {

        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        private readonly GetProductByIdHandler handler;

        public GetProductByIdHandlerTests()
        {
            var myProfile = new AutoMapperBussinesProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            IMapper mapper = new Mapper(configuration);
            mockUnitOfWork = new Mock<IUnitOfWork>();

            handler = new GetProductByIdHandler(mockUnitOfWork.Object, mapper);
        }

       

        [Fact]
        public async Task GetProductById_IdIs0_ThrowsException()
        {
            GetProductByIdQuery query = new GetProductByIdQuery(0);

            mockUnitOfWork.Setup(w => w.ProductRepository.FindSingle(It.IsAny<Expression<Func<Product, bool>>>()))
                .Throws(new Exception());

            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(query, new System.Threading.CancellationToken()));
        }
        [Fact]
        public async Task GetProductById_IdIsMinus1_ThrowsException()
        {
            GetProductByIdQuery query = new GetProductByIdQuery(-1);

            mockUnitOfWork.Setup(w => w.ProductRepository.FindSingle(It.IsAny<Expression<Func<Product, bool>>>()))
                .Throws(new Exception());

            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(query, new System.Threading.CancellationToken()));
        }

        [Fact]
        public async Task GetProductById_DataAccesMethodReturnsEntity_ReturnsDTO()
        {
            //Arange
            GetProductByIdQuery query = new GetProductByIdQuery(1);

            mockUnitOfWork.Setup(w => w.ProductRepository.FindSingle(It.IsAny<Expression<Func<Product, bool>>>()))
                .ReturnsAsync(new Product());

            //Act
            var ProductReturnedWithGivenId = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert

            Assert.IsAssignableFrom<ProductDTO>(ProductReturnedWithGivenId);
        }
        [Fact]
        public async Task GetProductById_DataAccesMethodReturnsProductObject_ReturnsTheSameObjectAsDataAccesReturned()
        {
            //Arange
            GetProductByIdQuery query = new GetProductByIdQuery(1);
            var ProductReturnedByDb = new Product() { Name = "A1" };

            mockUnitOfWork.Setup(w => w.ProductRepository.FindSingle(It.IsAny<Expression<Func<Product, bool>>>()))
                .ReturnsAsync(ProductReturnedByDb);

            //Act
            var ProductReturnedWithGivenId = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert


            Assert.Equal(ProductReturnedByDb.Name, ProductReturnedWithGivenId.Name);
        }

    }
}
