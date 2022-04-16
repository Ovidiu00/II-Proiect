using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.Requests.Commands;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories;

namespace OnlineStore.Business.Mediator.Handlers.CommandHandlers
{
    public class AddProductToCartCommandHandler : IRequestHandler<AddProductToCartCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public AddProductToCartCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.mediator = mediator;
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
                UserId = command.UserId.ToString(),
                ProductId = product.Id,
                Quantity = command.CartProductDto.Quantity
            };
            
            unitOfWork.
        }
    }
}