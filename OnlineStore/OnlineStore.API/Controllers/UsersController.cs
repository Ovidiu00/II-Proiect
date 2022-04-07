using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.UserCommands;
using System;
using System.Threading.Tasks;

namespace OnlineStore.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public UsersController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginDTO loginCredentials)
        {
            try
            {
                var token = await mediator.Send(new LoginCommand(loginCredentials));
                if (token == null)
                    return Unauthorized();

                return Ok(token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerCredentials)
        {
            try
            {
                var user = await mediator.Send(new RegisterCommand(registerCredentials));

                if (user == null)
                    return BadRequest(user);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
