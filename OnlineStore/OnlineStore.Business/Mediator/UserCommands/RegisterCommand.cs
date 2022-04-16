using MediatR;
using OnlineStore.Business.DTOs;

namespace OnlineStore.Business.Mediator.UserCommands
{
    public record RegisterCommand(RegisterDTO dto) : IRequest<UserDTO>;
}
