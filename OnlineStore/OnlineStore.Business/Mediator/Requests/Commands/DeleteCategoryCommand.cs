using MediatR;
using OnlineStore.Business.DTOs;

namespace OnlineStore.Business.Mediator.Requests.Commands
{
    public record DeleteCategoryCommand(int Id) : IRequest<bool>;

}