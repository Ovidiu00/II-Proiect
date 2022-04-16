using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.Requests.Queries;
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
            var orders = await unitOfWork.OrderRepository.Find(order => order.UserId.Equals(request.UserId.ToString()));
            throw new NotImplementedException();
        }
    }
}