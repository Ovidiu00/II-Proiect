using AutoMapper;
using MediatR;
using Moq;
using OnlineStore.Business.BusinessMapper;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.Handlers.CommandHandlers;
using OnlineStore.Business.Mediator.HelperCommands;
using OnlineStore.Business.Mediator.Requests.Commands;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
namespace OnlineStore.UnitTests.Mediator.CommandHandlers.Categories
{
    public class AddCategoryCommandTests
    {
        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        private readonly Mock<IMediator> mockMediator;

        private readonly AddCategoryCommandHandler handler;

        public AddCategoryCommandTests()
        {
            var myProfile = new AutoMapperBussinesProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            IMapper mapper = new Mapper(configuration);
            mockUnitOfWork = new Mock<IUnitOfWork>();
            mockMediator = new Mock<IMediator>();

            handler = new AddCategoryCommandHandler(mockUnitOfWork.Object, mapper,mockMediator.Object);
        }

        [Fact]
        public async Task AddProductCommand_ProductToBeAddedIsNull_ThrowsException()
        {
            AddCategoryCommand request = new AddCategoryCommand(null);

            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(request, new System.Threading.CancellationToken()));
        }
        [Fact]
        public async Task AddProductCommand_AllIsValid_SavePhotoCommandIsCalled()
        {
            AddCategoryCommand request = new AddCategoryCommand(new AddCategoryDTO());
            mockUnitOfWork.Setup(w => w.CategoryRepository.Add(It.IsAny<Category>()));

            await handler.Handle(request, It.IsAny<CancellationToken>());
            mockMediator.Verify(x => x.Send(It.IsAny<SavePhotoCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }
        [Fact]
        public async Task AddProductCommand_AllIsValid_CommitIsCalled()
        {
            AddCategoryCommand request = new AddCategoryCommand(new AddCategoryDTO());
            mockUnitOfWork.Setup(w => w.CategoryRepository.Add(It.IsAny<Category>()));

            await handler.Handle(request, It.IsAny<CancellationToken>());
            mockUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Fact]
        public async Task AddProductCommand_AllIsValid_ReturnsCategoryDTO()
        {
            AddCategoryCommand request = new AddCategoryCommand(new AddCategoryDTO());
            mockUnitOfWork.Setup(w => w.CategoryRepository.Add(It.IsAny<Category>()));

            var result = await handler.Handle(request, It.IsAny<CancellationToken>());
            Assert.IsAssignableFrom<CategoryDTO>(result);
        }

    }
}
