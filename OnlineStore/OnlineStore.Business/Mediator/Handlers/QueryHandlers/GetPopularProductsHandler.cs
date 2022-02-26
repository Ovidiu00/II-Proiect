using AutoMapper;
using MediatR;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.Requests.Queries;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Business.Mediator.Handlers.QueryHandlers
{
    public class GetPopularProductsHandler : IRequestHandler<GetPopularProductsQuery, IEnumerable<ProductDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetPopularProductsHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<ProductDTO>> Handle(GetPopularProductsQuery request, CancellationToken cancellationToken)
        {
            Dictionary<Product, int> productOrdersCount = await unitOfWork.ProductRepository.GetProductOrdersCountDictionary();
            if(productOrdersCount is null)
            {
                return new List<ProductDTO>();
            }

            var foo = productOrdersCount.OrderByDescending(o => o.Value).Select(x => mapper.Map<ProductDTO>(x.Key)).ToList();

            return foo.Take(request.count);
        }
    }
}
