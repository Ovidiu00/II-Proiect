using MediatR;
using OnlineStore.Business.DTOs;

namespace OnlineStore.Business.Mediator.Requests.Commands
{
    public record EditCategoryCommand(EditCategoryDTO EditCategoryDto, int id) : IRequest<CategoryDTO>;
}