using MediatR;

namespace OnlineStore.Business.Mediator.Requests.Commands
{
    public record RemoveFromCartCommand(int id,string currentUserId) : IRequest<bool>;
}
