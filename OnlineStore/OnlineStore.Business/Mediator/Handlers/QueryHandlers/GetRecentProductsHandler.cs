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
    public class GetRecentProductsHandler : IRequestHandler<GetRecentProductsQuery, IEnumerable<ProductDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetRecentProductsHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        
        public async Task<IEnumerable<ProductDTO>> Handle(GetRecentProductsQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<ProductDTO>>(await unitOfWork.ProductRepository.GetMostRecentProducts(request.count)) ;
        }
    }
}