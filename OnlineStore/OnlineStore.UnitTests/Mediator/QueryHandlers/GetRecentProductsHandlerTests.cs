using AutoMapper;
using Moq;
using Newtonsoft.Json;
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
    public class GetRecentProductsHandlerTests
    {
        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        private readonly GetRecentProductsHandler handler;

        public GetRecentProductsHandlerTests()
        {
            var myProfile = new AutoMapperBussinesProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            IMapper mapper = new Mapper(configuration);
            mockUnitOfWork = new Mock<IUnitOfWork>();

            handler = new GetRecentProductsHandler(mockUnitOfWork.Object, mapper);
        }
        
        [Fact]
        public async Task GetRecentsProdutsHandler_0ProductsQueriedFromDB_ReturnsEmptyList()
        {
            //Arange
            GetRecentProductsQuery query = new GetRecentProductsQuery(1);

            mockUnitOfWork.Setup(w => w.ProductRepository.GetAll()).ReturnsAsync(new List<Product>());

            //Act
            var actualRecentProducs = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert
            int expectedCount = 0;
            Assert.Equal(expectedCount, actualRecentProducs.Count());
        }
        [Fact]
        public async Task GetRecentProductsHandler_DataAccessMethodReturnsNull_ReturnsEmptyList()
        {
            //Arange
            GetRecentProductsQuery query = new GetRecentProductsQuery(1);

            mockUnitOfWork.Setup(w => w.ProductRepository.GetAll()).ReturnsAsync(null as List<Product>);

            //Act
            var actualRecentsProducts = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert
            int expectedCount = 0;
            Assert.Equal(expectedCount, actualRecentsProducts.Count());
        }
        
        [Fact]
        public async void GetRecentProductsHandler_NrOfRecordsArugmentIs0_ReturnsEmptyList()
        {
            //Arange
            GetRecentProductsQuery query = new GetRecentProductsQuery(0);

            mockUnitOfWork.Setup(w => w.ProductRepository.GetAll()).ReturnsAsync(new List<Product>());

            //Act
            var actualRecentProducts = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert
            int expectedCount = 0;
            Assert.Equal(expectedCount, actualRecentProducts.Count());
        }
    }
}
