using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineStore.Business.DTOs;
using OnlineStore.DataAccess.Models.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Business.Mediator.UserCommands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, UserDTO>
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public RegisterCommandHandler(UserManager<User> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<UserDTO> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            RegisterDTO dto = request.dto;
            if (dto == null)
                throw new NullReferenceException("Reigster Model is null!");

            if (dto.Password != dto.ConfirmPassword)
                throw new Exception("Passwords are different!");

            var user = new User(dto.Nume, dto.Nume, dto.Email);
            var result = await userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(System.Environment.NewLine, result.Errors.Select(x => x.Description));
                throw new Exception(errors);
            }

            return mapper.Map<UserDTO>(user);
        }
    }
}
