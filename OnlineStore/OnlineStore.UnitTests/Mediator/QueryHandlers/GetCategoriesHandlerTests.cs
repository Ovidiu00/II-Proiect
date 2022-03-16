using AutoMapper;
using Moq;
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
    public class GetCategoriesHandlerTests
    {

        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        private readonly GetCategoriesHandler handler;

        public GetCategoriesHandlerTests()
        {
            var myProfile = new AutoMapperBussinesProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            IMapper mapper = new Mapper(configuration);
            mockUnitOfWork = new Mock<IUnitOfWork>();

            handler = new GetCategoriesHandler(mockUnitOfWork.Object, mapper);
        }


        [Fact]
        public async Task Categories_DbReturnsEmptyList_ReturnsEmptyList()
        {
            //Arange

            GetCategoriesQuery query = new GetCategoriesQuery();

            mockUnitOfWork.Setup(w => w.CategoryRepository.GetBaseCategories())
                .ReturnsAsync(new List<Category>());

            //Act
            var categoriesReturnerByHandler = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert
            Assert.Empty(categoriesReturnerByHandler);
        }
        [Fact]
        public async Task Categories_DbReturnsNull_ReturnsEmptyList()
        {
            //Arange

            GetCategoriesQuery query = new GetCategoriesQuery();

            mockUnitOfWork.Setup(w => w.CategoryRepository.GetBaseCategories())
                .ReturnsAsync(null as List<Category>);

            //Act
            var categoriesReturnerByHandler = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert
            Assert.Empty(categoriesReturnerByHandler);
        }

        [Fact]
        public async Task Categories_DbReturnsCollectionOf3_ReturnsCollectioOf3()
        {
            //Arange

            GetCategoriesQuery query = new GetCategoriesQuery();
            List<Category> categoriesReturnedByDb = new List<Category>()
            {
              new Category(){},
              new Category(){},
              new Category(){},
            };

            mockUnitOfWork.Setup(w => w.CategoryRepository.GetBaseCategories())
                .ReturnsAsync(categoriesReturnedByDb);

            //Act
            var categoriesReturnerByHandler = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert
            Assert.Equal(categoriesReturnedByDb.Count,categoriesReturnerByHandler.Count());
        }
        [Fact]
        public async Task Categories_DbReturnsCollectionOfCategory_ReturnsCollectioOfCategoryDTO()
        {
            //Arange

            GetCategoriesQuery query = new GetCategoriesQuery();
            List<Category> categoriesReturnedByDb = new List<Category>();


            mockUnitOfWork.Setup(w => w.CategoryRepository.GetBaseCategories())
                .ReturnsAsync(categoriesReturnedByDb);

            //Act
            var categoriesReturnerByHandler = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert
            Assert.IsAssignableFrom<IEnumerable<CategoryDTO>>(categoriesReturnerByHandler);
        }
        [Fact]
        public async Task Categories_DbReturnsCollectionOfCategoryWithSubCategories_ReturnsCollectioOfCategoryDTOWithSubCategories()
        {
            //Arange

            GetCategoriesQuery query = new GetCategoriesQuery();
            List<Category> categoriesReturnedByDb = new List<Category>()
            {
                new Category()
                {
                    Id =1,
                    SubCategories = new List<Category>()
                    {
                        new Category()
                        {
                            Id = 1,
                            Name = "DA"
                        }
                    }
                }
            };


            mockUnitOfWork.Setup(w => w.CategoryRepository.GetBaseCategories())
                .ReturnsAsync(categoriesReturnedByDb);

            //Act
            var categoriesReturnerByHandler = await handler.Handle(query, new System.Threading.CancellationToken());

            //Asert
            Assert.IsAssignableFrom<IEnumerable<CategoryDTO>>(categoriesReturnerByHandler);
        }
    }
}
