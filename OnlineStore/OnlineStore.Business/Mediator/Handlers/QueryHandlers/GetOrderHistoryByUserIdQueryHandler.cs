using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.Requests.Queries;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories;

namespace OnlineStore.Business.Mediator.Handlers.QueryHandlers
{
    public class GetOrderHistoryByUserIdQueryHandler : IRequestHandler<GetOrderHistoryByUserIdQuery, IEnumerable<OrderDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetOrderHistoryByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<OrderDTO>> Handle(GetOrderHistoryByUserIdQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Order> orders = await unitOfWork.OrderRepository.GetOrders(request.userId);

            return orders.Select(x => new OrderDTO()
            {
                OrderId = x.Id,
                ProductVms = mapper.Map<IEnumerable<CartProductDTO>>(x.Products),
                OrderDate = x.DateOfOrder

            });
        }
    }
}