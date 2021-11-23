using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace el_proyecte_grande_sprint_1.Controllers
{
    public class AuthenticationController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
