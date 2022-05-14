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
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OnlineStore.UnitTests.Mediator.CommandHandlers.Products
{
    public class AddProductCommandTests
    {
        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        private readonly Mock<IMediator> mockMediator;
        private readonly AddProductCommandHandler handler;

        public AddProductCommandTests()
        {
            var myProfile = new AutoMapperBussinesProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            IMapper mapper = new Mapper(configuration);
            mockUnitOfWork = new Mock<IUnitOfWork>();
            mockMediator = new Mock<IMediator>();

            handler = new AddProductCommandHandler(mockUnitOfWork.Object, mapper, mockMediator.Object);
        }

        [Fact]
        public async Task AddProductCommand_ProductToBeAddedIsNull_ThrowsException()
        {
            AddProductCommand request = new AddProductCommand(null, 200);

            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(request, new System.Threading.CancellationToken()));
        }

        [Fact]
        public async Task AddProductCommand_AllIsValid_SavePhotoCommandIsCalled()
        {
            AddProductCommand request = new AddProductCommand(new AddProductDTO(), 2);
            mockUnitOfWork.Setup(w => w.CategoryRepository.FindSingle(It.IsAny<Expression<Func<Category, bool>>>()))
                        .ReturnsAsync(new Category());

            //Pentru a evita null reference exception la linia 39 din AddProductCommandHandler
            mockUnitOfWork.Setup(w => w.ProductRepository.Add(It.IsAny<Product>()));


            await handler.Handle(request, It.IsAny<CancellationToken>());
            mockMediator.Verify(x => x.Send(It.IsAny<SavePhotoCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }
        [Fact]
        public async Task AddProductCommand_CategoryFindSingleReturnsNull_ThrowsException()
        {
            AddProductCommand request = new AddProductCommand(new AddProductDTO(), 2);
            mockUnitOfWork.Setup(w => w.CategoryRepository.FindSingle(It.IsAny<Expression<Func<Category, bool>>>()))
                        .ReturnsAsync(null as Category);

            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(request, new System.Threading.CancellationToken()));
        }
        [Fact]
        public async Task AddProductCommand_AllIsValid_CommitIsCalled()
        {
            AddProductCommand request = new AddProductCommand(new AddProductDTO(), 2);
            mockUnitOfWork.Setup(w => w.CategoryRepository.FindSingle(It.IsAny<Expression<Func<Category, bool>>>()))
                                  .ReturnsAsync(new Category());

            //Pentru a evita null reference exception la linia 39 din AddProductCommandHandler
            mockUnitOfWork.Setup(w => w.ProductRepository.Add(It.IsAny<Product>()));

            await handler.Handle(request, It.IsAny<CancellationToken>());
            mockUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
