using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Moq;
using OnlineStore.Business.BusinessMapper;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.Handlers.CommandHandlers;
using OnlineStore.Business.Mediator.HelperCommands;
using OnlineStore.Business.Mediator.Requests.Commands;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OnlineStore.UnitTests.Mediator.CommandHandlers.Categories
{
    public class EditCategoryCommandTests
    {
        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        private readonly Mock<IMediator> mockMediator;

        private readonly EditCategoryCommandHandler handler;

        public EditCategoryCommandTests()
        {
            var myProfile = new AutoMapperBussinesProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            IMapper mapper = new Mapper(configuration);
            mockUnitOfWork = new Mock<IUnitOfWork>();
            mockMediator = new Mock<IMediator>();

            handler = new EditCategoryCommandHandler(mockUnitOfWork.Object, mapper,mockMediator.Object);
        }
        [Fact]
        public async Task EditCategoryCommand_CategoryToBeAddedIsNull_ThrowsException()
        {
            EditCategoryCommand request = new EditCategoryCommand(null,2);

            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(request, new System.Threading.CancellationToken()));
        }
        [Fact]
        public async Task EditCategoryCommand_AllIsValid_SavePhotoCommandIsCalled()
        {
            var fileMock = new Mock<IFormFile>();

            var editCategoryDTO = new EditCategoryDTO()
            {
                Photo = fileMock.Object
            };
            EditCategoryCommand request = new EditCategoryCommand(editCategoryDTO, 2);

            mockUnitOfWork.Setup(w => w.CategoryRepository.FindSingle(It.IsAny<Expression<Func<Category, bool>>>()))
             .ReturnsAsync(new Category());

            await handler.Handle(request, It.IsAny<CancellationToken>());
            mockMediator.Verify(x => x.Send(It.IsAny<SavePhotoCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }
        [Fact]
        public async Task EditCategoryCommand_DBReturnsNull_ThrowsException()
        {
            EditCategoryCommand request = new EditCategoryCommand(new EditCategoryDTO(), 2);

            mockUnitOfWork.Setup(w => w.CategoryRepository.FindSingle(It.IsAny<Expression<Func<Category, bool>>>()))
             .ReturnsAsync(null as Category);
            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(request, new System.Threading.CancellationToken()));

        }

        [Fact]
        public async Task AddProductCommand_AllIsValid_CallsCommit()
        {
            var fileMock = new Mock<IFormFile>();

            var editCategoryDTO = new EditCategoryDTO()
            {
                Photo = fileMock.Object
            };
            EditCategoryCommand request = new EditCategoryCommand(editCategoryDTO, 2);

            mockUnitOfWork.Setup(w => w.CategoryRepository.FindSingle(It.IsAny<Expression<Func<Category, bool>>>()))
             .ReturnsAsync(new Category());

            await handler.Handle(request, It.IsAny<CancellationToken>());
            mockUnitOfWork.Verify(x =>x.Commit(), Times.Once);
        }
    }
}
