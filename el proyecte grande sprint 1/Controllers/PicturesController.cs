using Azure.Storage.Blobs;
using el_proyecte_grande_sprint_1.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace el_proyecte_grande_sprint_1.Controllers
{
    [Route("api/pictures")]
    [ApiController]
    public class PicturesController : ControllerBase
    {

        private readonly ILogger<PicturesController> _logger;

        private IPictureStorage _pictureStorage;

        private IConfiguration _configuration;
        public PicturesController(ILogger<PicturesController> logger, IPictureStorage pictureStorage, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }


        [HttpPost]
        public async Task<ActionResult> CreateImage([FromForm] ImageDTO img)
        {
            using var memoryStream = new MemoryStream();
            await img.Image.CopyToAsync(memoryStream);

            BlobServiceClient blobServiceClient = new BlobServiceClient(_configuration["AzureStorageConnectionString"]);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_configuration["ContentContainer"]);
            BlobClient blobClient = containerClient.GetBlobClient(img.Image.FileName);

            memoryStream.Seek(0, SeekOrigin.Begin);

            await blobClient.UploadAsync(memoryStream, true);

            return Ok();
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AzurePictureDTO>>>GetAllPicturesFromBlobContainer()
        {
            var blobContainerClient = new BlobContainerClient(_configuration["AzureStorageConnectionString"], _configuration["ContentContainer"]);
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