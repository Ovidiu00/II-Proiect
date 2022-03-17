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
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetCategoryByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CategoryDTO> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            Category category = await unitOfWork.CategoryRepository.GetCategory(request.id);
            return mapper.Map<CategoryDTO>(category);
        }
    }
}