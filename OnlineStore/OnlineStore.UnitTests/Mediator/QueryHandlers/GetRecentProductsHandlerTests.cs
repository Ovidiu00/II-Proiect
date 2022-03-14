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
        public async Task GetRecentProductsHandler_ProductsAreRandomlyQueriedFromDB_ReturnsProductsOrderedByInsertedDateDescending()
        {
            //Arange

            GetRecentProductsQuery query = new GetRecentProductsQuery(1);

            List<Product> productsReturnedByDb = new List<Product>()
            {
                 new Product(){Name="Product4",InsertedDate = DateTime.Now.AddDays(-5)},
                 new Product(){Name="Product5",InsertedDate = DateTime.Now.AddDays(-20)},
                 new Product(){Name="Product3",InsertedDate = DateTime.Now.AddDays(-1)},
                 new Product(){Name="Product2",InsertedDate = DateTime.Now.AddDays(-11)},
                 new Product(){Name="Product1",InsertedDate = DateTime.Now.AddDays(-15)},
            };

            IEnumerable<ProductDTO> expectedRecentProducts = new List<ProductDTO>()
            {
                 new ProductDTO(){Name="Product3",InsertedDate = DateTime.Now.AddDays(-1)},
                 new ProductDTO(){Name="Product4",InsertedDate = DateTime.Now.AddDays(-5)},
                 new ProductDTO(){Name="Product2",InsertedDate = DateTime.Now.AddDays(-11)},
                 new ProductDTO(){Name="Product1",InsertedDate = DateTime.Now.AddDays(-15)},
                 new ProductDTO(){Name="Product5",InsertedDate = DateTime.Now.AddDays(-20)},
            };

            mockUnitOfWork.Setup(w => w.ProductRepository.GetAll())
                .ReturnsAsync(productsReturnedByDb);

            //Act
            var actualRecentProducts = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert

            Assert.Equal(JsonConvert.SerializeObject(expectedRecentProducts), JsonConvert.SerializeObject(actualRecentProducts));
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
        public async void GetRecentProductsHandler_DbReturnsAListOf10ProductsAndNrOfProductsIs5_ReturnsAListOf5Elements()
        {
            //Arange
            int nrOfProducts = 5;
            GetRecentProductsQuery query = new GetRecentProductsQuery(nrOfProducts);
            List<Product> productsReturnedByDb = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                productsReturnedByDb.Add(new Product());
            }

            mockUnitOfWork.Setup(w => w.ProductRepository.GetAll()).ReturnsAsync(productsReturnedByDb);

            //Act
            var actualRecentProducts = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert
            int expectedCount = nrOfProducts;
            Assert.Equal(expectedCount, actualRecentProducts.Count());
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
