﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineStore.API.AutoMapper;
using OnlineStore.API.Controllers;
using OnlineStore.API.ViewModels;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.Requests.Commands;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
namespace OnlineStore.UnitTests.API.CategoryController_Tests
{
    public class EditCategoryTests
    {
        private readonly Mock<IMediator> mockMediator;
        private readonly IMapper mapper;

        private readonly CategoryController controller;

        public EditCategoryTests()
        {
            mockMediator = new Mock<IMediator>();

            var myProfile = new AutoMapperApiProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapper = new Mapper(configuration);

            controller = new CategoryController(mockMediator.Object, mapper);
        }

        [Fact]
        public async Task EditCategory_EditCategoryVMIsNull_ReturnsBadRequest()
        {
            //// Act
            var actionResult = await controller.EditCategory(null,2);

            //// Assert
            Assert.IsType<BadRequestResult>(actionResult);
        }
        [Fact]
        public async Task EditCategory_IdIs0_ReturnsBadRequest()
        {
            //// Act
            var actionResult = await controller.EditCategory(null, 0);

            //// Assert
            Assert.IsType<BadRequestResult>(actionResult);
        }
        [Fact]
        public async Task EditCategory_AllIsValid_EditCategoryCommandCalledOnce()
        {
            // Arrange
            mockMediator.Setup(repo => repo.Send(It.IsAny<EditCategoryCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CategoryDTO());

            //// Act
            var actionResult = await controller.EditCategory(new EditCategoryVM(),2);

            //// Assert
            mockMediator.Verify(x => x.Send(It.IsAny<EditCategoryCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
