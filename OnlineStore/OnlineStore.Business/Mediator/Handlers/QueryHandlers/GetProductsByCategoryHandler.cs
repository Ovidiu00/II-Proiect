using AutoMapper;
using MediatR;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.Requests.Queries;
using OnlineStore.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Business.Mediator.Handlers.QueryHandlers
{
    public class GetProductsByCategoryHandler : IRequestHandler<GetProductsByCategoryQuery, IEnumerable<ProductDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetProductsByCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<ProductDTO>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            if (request.categoryId <= 0)
                throw new Exception();

            var categoryById = await unitOfWork.CategoryRepository.GetCategoryWithProducts(request.categoryId);
            if (categoryById == null)
            {
                throw new Exception("This category doesen't exist.");
            }

            var productsForGivenCategory = categoryById.Products;
            return mapper.Map<IEnumerable<ProductDTO>>(productsForGivenCategory);
        }

    }
}
