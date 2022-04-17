using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.Requests.Queries;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories;

namespace OnlineStore.Business.Mediator.Handlers.QueryHandlers
{
    public class GetCartProductsByUserIdQueryHandler : IRequestHandler<GetCartProductsByUserIdQuery, IEnumerable<CartProductDTO>>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<User> userManager;

        public GetCartProductsByUserIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<CartProductDTO>> Handle(GetCartProductsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var cart = await unitOfWork.OrderRepository.GetProductsInCart(request.UserId);
        
            var products = mapper.Map<IEnumerable<CartProductDTO>>(cart);
            return products;
        }
    }
}