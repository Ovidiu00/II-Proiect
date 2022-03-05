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
    public class GetCategoryByIdHandlerTests
    {
        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        private readonly GetCategoryByIdHandler handler;

        public GetCategoryByIdHandlerTests()
        {
            var myProfile = new AutoMapperBussinesProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            IMapper mapper = new Mapper(configuration);
            mockUnitOfWork = new Mock<IUnitOfWork>();

            handler = new GetCategoryByIdHandler(mockUnitOfWork.Object, mapper);
        }


        [Fact]
        public async Task GetProductById_IdIs0_ThrowsException()
        {
            GetCategoryByIdQuery query = new GetCategoryByIdQuery(0);

            mockUnitOfWork.Setup(w => w.CategoryRepository.FindSingle(It.IsAny<Expression<Func<Category, bool>>>()))
                .Throws(new Exception());

            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(query, new System.Threading.CancellationToken()));
        }
        [Fact]
        public async Task GetProductById_IdIsMinus1_ThrowsException()
        {
            GetCategoryByIdQuery query = new GetCategoryByIdQuery(-1);

            mockUnitOfWork.Setup(w => w.CategoryRepository.FindSingle(It.IsAny<Expression<Func<Category, bool>>>()))
                .Throws(new Exception());

            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(query, new System.Threading.CancellationToken()));
        }

        [Fact]
        public async Task GetProductById_DataAccesMethodDoesntFindCategoryWithGivenId_ReturnsNull()
        {
            //Arange
            GetCategoryByIdQuery query = new GetCategoryByIdQuery(It.IsAny<int>());

            mockUnitOfWork.Setup(w => w.CategoryRepository.FindSingle(It.IsAny<Expression<Func<Category, bool>>>()))
                .ReturnsAsync(null as Category);

            //Act
            var categoryReturnedWithGivenId = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert
            Assert.Null(categoryReturnedWithGivenId);

        }
        [Fact]
        public async Task GetProductById_DataAccesMethodReturnsDTO_ReturnsVM()
        {
            //Arange
            GetCategoryByIdQuery query = new GetCategoryByIdQuery(It.IsAny<int>());

            mockUnitOfWork.Setup(w => w.CategoryRepository.FindSingle(It.IsAny<Expression<Func<Category, bool>>>()))
                .ReturnsAsync(new Category());

            //Act
            var categoryReturnedWithGivenId = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert

            Assert.IsAssignableFrom<CategoryDTO>(categoryReturnedWithGivenId);
        }
        [Fact]
        public async Task GetProductById_DataAccesMethodReturnsCategoryObject_ReturnsTheSameObjectAsDataAccesReturned()
        {
            //Arange
            GetCategoryByIdQuery query = new GetCategoryByIdQuery(It.IsAny<int>());
            var categoryReturnedByDb = new Category() { Name = "A1" };

            mockUnitOfWork.Setup(w => w.CategoryRepository.FindSingle(It.IsAny<Expression<Func<Category, bool>>>()))
                .ReturnsAsync(new Category());

            //Act
            var categoryReturnedWithGivenId = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert


            Assert.Equal(categoryReturnedByDb.Name, categoryReturnedWithGivenId.Name);
        }
    }
}
