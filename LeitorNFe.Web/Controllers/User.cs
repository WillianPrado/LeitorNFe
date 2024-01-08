using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace LeitorNFe.Web.Controllers
{
    [Route("/api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromQuery] string email, [FromQuery] string password)
        {
            try
            {
                return email;
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Algo deu errado, tente mais tarde!" });
            }

        }
    }
}
