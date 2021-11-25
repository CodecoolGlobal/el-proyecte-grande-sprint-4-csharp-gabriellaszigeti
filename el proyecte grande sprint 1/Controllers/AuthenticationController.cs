using el_proyecte_grande_sprint_1.Models.DTO;
using el_proyecte_grande_sprint_1.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace el_proyecte_grande_sprint_1.Controllers
{
    [Route("/api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationRepository _authenticationRepository;

        public AuthenticationController(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            await _authenticationRepository.AddUser(user);
            return Ok();
        }

        [HttpPost]
        [Route("user-validation")]
        public async Task<ActionResult<string>> CheckIfUserIsRegistered([FromBody] UserDTO partialUserData)
        {
            var result = await _authenticationRepository.CheckIfUserAlreadyRegistered(partialUserData);
            return Ok(result.ToString());
        }


    }
}
