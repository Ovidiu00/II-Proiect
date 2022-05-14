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
    public class EditProductCommandTests
    {
        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        private readonly Mock<IMediator> mockMediator;
        private readonly EditProductCommandHandler handler;

        public EditProductCommandTests()
        {
            var myProfile = new AutoMapperBussinesProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            IMapper mapper = new Mapper(configuration);
            mockUnitOfWork = new Mock<IUnitOfWork>();
            mockMediator = new Mock<IMediator>();

            handler = new EditProductCommandHandler(mockUnitOfWork.Object, mapper, mockMediator.Object);
        }


    }
}