using AutoMapper;
using Moq;
using OnlineStore.Business.BusinessMapper;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.Handlers.QueryHandlers;
using OnlineStore.Business.Mediator.Requests.Queries;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OnlineStore.UnitTests.Mediator.QueryHandlers
{
    public class GetProductsByCategoryHandlerTests
    {
        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        private readonly GetProductsByCategoryHandler handler;

        public GetProductsByCategoryHandlerTests()
        {
            var myProfile = new AutoMapperBussinesProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            IMapper mapper = new Mapper(configuration);
            mockUnitOfWork = new Mock<IUnitOfWork>();

            handler = new GetProductsByCategoryHandler(mockUnitOfWork.Object, mapper);
        }

        [Fact]
        public async Task GetProductsByCategoryHandler_IdIs0_ThrowsException()
        {
            GetProductsByCategoryQuery query = new GetProductsByCategoryQuery(0);

            mockUnitOfWork.Setup(w => w.CategoryRepository.GetCategoryWithProducts(It.IsAny<int>()))
              .ReturnsAsync(new Category());

            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(query, new System.Threading.CancellationToken()));
        }
        [Fact]
        public async Task GetProductsByCategoryHandler_IdIsMinus1_ThrowsException()
        {
            GetProductsByCategoryQuery query = new GetProductsByCategoryQuery(-1);

            mockUnitOfWork.Setup(w => w.CategoryRepository.GetCategoryWithProducts(It.IsAny<int>()))
              .ReturnsAsync(new Category());

            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(query, new System.Threading.CancellationToken()));
        }

        [Fact]
        public async Task GetProductsByCategoryHandler_DBReturnsNull_ThrowsException()
        {
            GetProductsByCategoryQuery query = new GetProductsByCategoryQuery(4);

            mockUnitOfWork.Setup(w => w.CategoryRepository.GetCategoryWithProducts(It.IsAny<int>()))
              .ReturnsAsync( null as Category);

            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(query, new System.Threading.CancellationToken()));
        }

        [Fact]
        public async Task GetProductsByCategoryHandler_DataAccesMethodReturnsCategoryEntity_ReturnsProductListDTO()
        {
            //Arange
            GetProductsByCategoryQuery query = new GetProductsByCategoryQuery(53);

            mockUnitOfWork.Setup(w => w.CategoryRepository.GetCategoryWithProducts(It.IsAny<int>()))
                .ReturnsAsync(new Category());

            //Act
            var ProductReturnedWithGivenId = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert

            Assert.IsAssignableFrom<IEnumerable<ProductDTO>>(ProductReturnedWithGivenId);
        }

        [Fact]
        public async Task GetProductsByCategoryHandler_DataAccesMethodReturnsCategoryWith1Product_ReturnsThe1Product()
        {
            //Arange
            GetProductsByCategoryQuery query = new GetProductsByCategoryQuery(53);

            var categoryReturnedByDB = new Category()
            {
                Products = new List<Product>()
                {
                    new Product()
                    {
                        Name ="Papuci"
                    }
                }
            };
            mockUnitOfWork.Setup(w => w.CategoryRepository.GetCategoryWithProducts(It.IsAny<int>()))
                .ReturnsAsync(categoryReturnedByDB);

            //Act
            var productsReturnedByHandler = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert

            Assert.Equal("Papuci", productsReturnedByHandler.First().Name);
        }


    }
}
