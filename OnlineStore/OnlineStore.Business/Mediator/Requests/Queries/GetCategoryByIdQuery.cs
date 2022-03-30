using MediatR;
using OnlineStore.Business.DTOs;

namespace OnlineStore.Business.Mediator.Requests.Queries
{
    public record GetCategoryByIdQuery(int id) : IRequest<CategoryDTO>;
   
}