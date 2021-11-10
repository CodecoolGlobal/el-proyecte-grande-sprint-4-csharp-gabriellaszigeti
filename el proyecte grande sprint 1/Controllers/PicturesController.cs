using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using el_proyecte_grande_sprint_1.Models.DTO;

namespace el_proyecte_grande_sprint_1.Controllers
{
    [Route("api/pictures")]
    [ApiController]
    public class PicturesController : ControllerBase
    {

        private readonly ILogger<PicturesController> _logger;

        private IPictureStorage _pictureStorage;
        public PicturesController(ILogger<PicturesController> logger, IPictureStorage pictureStorage)
        {
            _logger = logger;
            _pictureStorage = pictureStorage;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Picture>> GetAllPictures()
        {
            var pictures = _pictureStorage.GetAllPictures();
            if (pictures == null)
                return NotFound();
            else
            {
                return Ok(pictures);
            }
        }


        [HttpPost]
        public IActionResult CreateImage([FromForm] ImageDTO img)
        {
            return Ok();
        }

    }
}
