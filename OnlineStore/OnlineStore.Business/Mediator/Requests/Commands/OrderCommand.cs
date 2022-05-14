using MediatR;

namespace OnlineStore.Business.Mediator.Requests.Commands
{
    public record OrderCommand(string UserId) : IRequest<bool>;
}
