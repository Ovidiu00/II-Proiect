using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.Requests.Commands;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories;

namespace OnlineStore.Business.Mediator.Handlers.CommandHandlers
{
    public class AddProductToCartCommandHandler : IRequestHandler<AddProductToCartCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<User> userManager;

        public AddProductToCartCommandHandler(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        public async Task<bool> Handle(AddProductToCartCommand command, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.ProductRepository.FindSingle(product => product.Id.Equals(command.CartProductDto.Id));
            if (product == null)
            {
                throw new Exception("The product doesn't exist!");
            }
           
            UserProduct newUserProduct = new UserProduct()
            {
                UserId = command.UserId,
                ProductId = product.Id,
                Quantity = command.CartProductDto.Quantity
            };
            var user = await userManager.FindByIdAsync(command.UserId.ToString());
            user.Products.Add(newUserProduct);
            await unitOfWork.Commit();
            return true;
        }
    }
}