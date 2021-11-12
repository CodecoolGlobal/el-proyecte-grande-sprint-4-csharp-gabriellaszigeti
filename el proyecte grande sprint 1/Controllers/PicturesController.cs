using Azure.Storage.Blobs;
using el_proyecte_grande_sprint_1.Models.DTO;
using el_proyecte_grande_sprint_1.Services;
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
        private IConfiguration _configuration;
        private IAzureBlobStorageService _azureBlobStorageService;

        public PicturesController(ILogger<PicturesController> logger, IPictureStorage pictureStorage,
            IConfiguration configuration, IAzureBlobStorageService azureBlobStorageService)
        {
            _logger = logger;
            _configuration = configuration;
            _azureBlobStorageService = azureBlobStorageService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AzurePictureDTO>>>GetAllPicturesFromBlobContainer()
        {
            var picturesFromAzureContainer = await
                _azureBlobStorageService.GetAllPicturesFromBlobContainer(_configuration["ContentContainer"]);

            return Ok(picturesFromAzureContainer);

        }

        [HttpPost]
        public async Task<ActionResult> CreateImage([FromForm] ImageUploadDTO img)
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
    }
}