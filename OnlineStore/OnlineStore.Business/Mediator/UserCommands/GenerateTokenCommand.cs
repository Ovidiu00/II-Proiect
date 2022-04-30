using MediatR;
using System.Collections.Generic;

namespace OnlineStore.Business.Mediator.UserCommands
{
    public record GenerateTokenCommand(string email,string password,IList<string> roles) : IRequest<string>;
}
