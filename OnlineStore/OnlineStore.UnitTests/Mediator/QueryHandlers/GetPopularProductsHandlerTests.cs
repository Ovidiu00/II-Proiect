using AutoMapper;
using Moq;
using Newtonsoft.Json;
using OnlineStore.Business.BusinessMapper;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.Handlers.QueryHandlers;
using OnlineStore.Business.Mediator.Requests.Queries;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OnlineStore.UnitTests.Mediator.QueryHandlers
{
    public class GetPopularProductsHandlerTests
    {
        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        private readonly GetPopularProductsHandler handler;

        public GetPopularProductsHandlerTests()
        {
            var myProfile = new AutoMapperBussinesProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            IMapper mapper = new Mapper(configuration);
            mockUnitOfWork = new Mock<IUnitOfWork>();

            handler = new GetPopularProductsHandler(mockUnitOfWork.Object, mapper);
        }


        [Fact]
        public async Task GetPopularProductsHandler_ProductsAreRandomlyQueriedFromDB_ReturnsProductsOrderedByOrdersCountDescending()
        {
            //Arange
            GetPopularProductsQuery query = new GetPopularProductsQuery(5);
            Dictionary<Product, int> productOrderCountDictionary = new Dictionary<Product, int>()
            {
                { new Product(){Name="Product1"},1 },
                { new Product(){Name="Product2"},5 },
                { new Product(){Name="Product3"},6 },
                { new Product(){Name="Product4"},23 },
                { new Product(){Name="Product5"},10 },
            };
            IEnumerable<ProductDTO> expectedPopularProducts = new List<ProductDTO>()
            {
                 new ProductDTO(){Name="Product4"},
                 new ProductDTO(){Name="Product5"},
                 new ProductDTO(){Name="Product3"},
                 new ProductDTO(){Name="Product2"},
                 new ProductDTO(){Name="Product1"},
            };
                                                      
            mockUnitOfWork.Setup(w => w.ProductRepository.GetProductOrdersCountDictionary()).ReturnsAsync(productOrderCountDictionary);

            //Act
            var actualPopularProducts = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert

            Assert.Equal(JsonConvert.SerializeObject(expectedPopularProducts), JsonConvert.SerializeObject(actualPopularProducts));
        }
        [Fact]
        public async Task GetPopularProductsHandler_0ProductsQueriedFromDB_ReturnsEmptyList()
        {
            //Arange
            GetPopularProductsQuery query = new GetPopularProductsQuery(It.IsAny<int>());
            Dictionary<Product, int> productOrderCountDictionary = new Dictionary<Product, int>();

            mockUnitOfWork.Setup(w => w.ProductRepository.GetProductOrdersCountDictionary()).ReturnsAsync(productOrderCountDictionary);

            //Act
            var actualPopularProducts = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert
            int expectedCount = 0;
            Assert.Equal(expectedCount,actualPopularProducts.Count());
        }
        [Fact]
        public async Task GetPopularProductsHandler_DataAccessMethodReturnsNull_ReturnsEmptyList()
        {
            //Arange
            GetPopularProductsQuery query = new GetPopularProductsQuery(It.IsAny<int>());

            mockUnitOfWork.Setup(w => w.ProductRepository.GetProductOrdersCountDictionary()).ReturnsAsync(null as Dictionary<Product, int>);

            //Act
            var actualPopularProducts = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert
            int expectedCount = 0;
            Assert.Equal(expectedCount, actualPopularProducts.Count());
        }
        [Fact]
        public async void GetPopularProductsHandler_DbReturnsAListOf10ProductsAndNrOfProductsIs5_ReturnsAListOf5Elements()
        {
            //Arange
            int nrOfProducts = 5;
            GetPopularProductsQuery query = new GetPopularProductsQuery(nrOfProducts);
            Dictionary<Product, int> productOrderCountDictionary = new Dictionary<Product, int>();

            for(int i= 0; i < 10; i++)
            {
                productOrderCountDictionary.Add(new Product(), 1);
            }

            mockUnitOfWork.Setup(w => w.ProductRepository.GetProductOrdersCountDictionary()).ReturnsAsync(productOrderCountDictionary);

            //Act
            var actualPopularProducts = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert
            int expectedCount = nrOfProducts;
            Assert.Equal(expectedCount, actualPopularProducts.Count());
        }

        [Fact]
        public async void GetPopularProductsHandler_NrOfRecordsArugmentIs0_ReturnsEmptyList()
        {
            //Arange
            GetPopularProductsQuery query = new GetPopularProductsQuery(0);
            Dictionary<Product, int> productOrderCountDictionary = new Dictionary<Product, int>();

            mockUnitOfWork.Setup(w => w.ProductRepository.GetProductOrdersCountDictionary()).ReturnsAsync(productOrderCountDictionary);

            //Act
            var actualPopularProducts = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert
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
        public async void GetPopularProductsHandler_NrOfRecordsArugmentIsNegative_ReturnsEmptyList(int negativeNrOfProducts)
        {
            //Arange
            GetPopularProductsQuery query = new GetPopularProductsQuery(negativeNrOfProducts);
            Dictionary<Product, int> productOrderCountDictionary = new Dictionary<Product, int>();



            mockUnitOfWork.Setup(w => w.ProductRepository.GetProductOrdersCountDictionary()).ReturnsAsync(null as Dictionary<Product, int>);

            //Act
            var actualPopularProducts = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert
            int expectedCount = 0;
            Assert.Equal(expectedCount, actualPopularProducts.Count());
        }
    }
}
