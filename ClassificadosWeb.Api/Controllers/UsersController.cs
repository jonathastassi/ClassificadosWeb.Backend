using System;
using System.Security.Claims;
using System.Threading.Tasks;
using ClassificadosWeb.Api.Models;
using ClassificadosWeb.Domain.Entities;
using ClassificadosWeb.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClassificadosWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UsersController(
            IUserRepository userRepository
        )
        {
            this.userRepository = userRepository;
        }


        [HttpPost("Me")]
        public async Task<IActionResult> Me()
        {
            try
            {
                Guid UserId = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid).Value);

                if (UserId == null)
                {
                    throw new ArgumentNullException("User incorrect");
                }

                UserEntity user = await this.userRepository.GetById(UserId);
                user.SetPassword(null);

                return Ok(new ResponseApi(true, user));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /*
        Método protegido para o usuário, alterar seus dados e sua foto
        
        método para upload de foto
        */
    }
}