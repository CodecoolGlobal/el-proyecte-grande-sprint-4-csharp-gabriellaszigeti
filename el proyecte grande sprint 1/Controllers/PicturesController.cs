using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using el_proyecte_grande_sprint_1.Models.DTO;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Azure.Storage.Blobs;

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
        public async Task<ActionResult>CreateImage([FromForm] ImageDTO img)
        {
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=projectlens;AccountKey=9ras80E5iOB1hxIXVm00ew+bY42Pp9BQEf4kcPwqQG59OPQ6FLcr1uPu0q/6DLJn5Djld2cHr4JSlx6WE8bYBQ==;EndpointSuffix=core.windows.net";
            using var memoryStream = new MemoryStream();
            await img.Image.CopyToAsync(memoryStream);
            //using var imageToConvert = Image.FromStream(memoryStream);
            //imageToConvert.Save("myfile.png", ImageFormat.Png);

            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("projectlens-blob1");

            BlobClient blobClient = containerClient.GetBlobClient(img.Image.FileName);

            memoryStream.Seek(0, SeekOrigin.Begin);
            await blobClient.UploadAsync(memoryStream, true);



            return Ok();

        }

    }
}