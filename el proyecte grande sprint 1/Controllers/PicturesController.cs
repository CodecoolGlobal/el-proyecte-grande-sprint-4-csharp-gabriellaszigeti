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
using Azure.Storage.Blobs.Models;

namespace el_proyecte_grande_sprint_1.Controllers
{
    [Route("api/pictures")]
    [ApiController]
    public class PicturesController : ControllerBase
    {

        private readonly ILogger<PicturesController> _logger;
        private string _connectionString = "DefaultEndpointsProtocol=https;AccountName=projectlens;AccountKey=9ras80E5iOB1hxIXVm00ew+bY42Pp9BQEf4kcPwqQG59OPQ6FLcr1uPu0q/6DLJn5Djld2cHr4JSlx6WE8bYBQ==;EndpointSuffix=core.windows.net";
        private string _blobContainerName = "projectlens-blob1";


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
        public async Task<ActionResult> CreateImage([FromForm] ImageDTO img)
        {
            using var memoryStream = new MemoryStream();
            await img.Image.CopyToAsync(memoryStream);

            BlobServiceClient blobServiceClient = new BlobServiceClient(_connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_blobContainerName);
            BlobClient blobClient = containerClient.GetBlobClient(img.Image.FileName);

            memoryStream.Seek(0, SeekOrigin.Begin);

            await blobClient.UploadAsync(memoryStream, true);

            return Ok();
        }


        [HttpGet]
        [Route("get-all-pictures")]
        public async Task<ActionResult<IEnumerable<AzurePictureDTO>>>GetAllPicturesFromBlobContainer()
        {
            var blobContainerClient = new BlobContainerClient(_connectionString, _blobContainerName);
            List<AzurePictureDTO> azurePictures = new List<AzurePictureDTO>();

            await foreach (var blobItem in blobContainerClient.GetBlobsAsync())
            {
                var blobClient = blobContainerClient.GetBlobClient(blobItem.Name);
                var uri = blobClient.Uri;

                AzurePictureDTO azurePicture = new AzurePictureDTO(uri.OriginalString, blobItem.Name, blobItem.Name);
                azurePictures.Add(azurePicture);
            }

            return Ok(azurePictures);

        }

    }
}