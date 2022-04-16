using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineStore.Business.DTOs;
using OnlineStore.DataAccess.Models.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Business.Mediator.UserCommands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseDTO>
    {
        private readonly UserManager<User> userManager;
        private readonly IMediator mediator;

        public LoginCommandHandler(UserManager<User> userManager,IMediator mediator)
        {
            this.userManager = userManager;
            this.mediator = mediator;
        }
        public async Task<LoginResponseDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.dto.Email);
            if (user == null)
                throw new Exception("Can't find user given this email!");

            var result = await userManager.CheckPasswordAsync(user, request.dto.Password);
            if (!result)
                throw new Exception("Email - password combination is incorrect!");

            var roles = await userManager.GetRolesAsync(user);
            var token = await mediator.Send(new GenerateTokenCommand(request.dto.Email, request.dto.Password,roles));
            if(string.IsNullOrEmpty(token))
                throw new Exception("Something went wrong ...");

            return new LoginResponseDTO(token,new UserDTO() {Nume = user.Nume,Prenume = user.Prenume});
        }
    }
}
