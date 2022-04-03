using MediatR;

namespace OnlineStore.Business.Mediator.Requests.Commands
{
    public record DeleteProductCommand(int id) : IRequest<bool>;

}
