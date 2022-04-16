using MediatR;
using OnlineStore.Business.DTOs;

namespace OnlineStore.Business.Mediator.UserCommands
{
    public record LoginCommand(LoginDTO dto) : IRequest<LoginResponseDTO>;
}
