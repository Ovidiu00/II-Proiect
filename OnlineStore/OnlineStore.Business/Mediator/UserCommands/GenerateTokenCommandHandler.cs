using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Business.Mediator.UserCommands
{
    public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, string>
    {
        private readonly string TokenKey;

        public GenerateTokenCommandHandler(IConfiguration configuration)
        {
            this.TokenKey = configuration.GetValue<string>("TokenKey");
        }
        public async Task<string> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
        {
            List<Claim> Claims = new List<Claim>()
            {
               new Claim(ClaimTypes.Email, request.email),
            };
            foreach (var role in request.roles)
            {
                Claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(TokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claims),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return await Task.FromResult(tokenHandler.WriteToken(token));
        }
    }
}
