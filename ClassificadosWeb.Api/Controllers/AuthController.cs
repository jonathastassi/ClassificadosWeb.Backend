using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassificadosWeb.Api.Configurations;
using ClassificadosWeb.Api.Models;
using ClassificadosWeb.Domain.Commands.User;
using ClassificadosWeb.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClassificadosWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand command)
        {
            try
            {
                var response = await this.mediator.Send(command);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }    

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command, [FromServices] SigningConfigurations signingConfigurations,
            [FromServices] TokenConfigurations tokenConfigurations)
        {
            try
            {
                var response = await this.mediator.Send(command);
                
                if (response.Success == true)
                {
                    UserAuth user = (UserAuth)((UserEntity)response.Data);
                    var token = GenerateToken.Generate(user, signingConfigurations, tokenConfigurations);
                    return Ok(token);
                }
                return BadRequest(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

        [HttpPost("Me")]
        public void Me()
        {
            // retornar os dados do usuário logado
        }
    }
}