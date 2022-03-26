using MediatR;
using OnlineStore.Business.DTOs;

namespace OnlineStore.Business.Mediator.Requests.Commands
{
    public record AddCategoryCommand(AddCategoryDTO AddCategoryDto) : IRequest<CategoryDTO>;
}