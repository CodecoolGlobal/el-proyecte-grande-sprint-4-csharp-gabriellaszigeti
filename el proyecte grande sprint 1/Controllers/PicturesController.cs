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
        private IPictureStorage _pictureStorage;
        private string _contentContainer;


        public PicturesController(ILogger<PicturesController> logger, IPictureStorage pictureStorage,
            IConfiguration configuration, IAzureBlobStorageService azureBlobStorageService)
        {
            _logger = logger;
            _configuration = configuration;
            _azureBlobStorageService = azureBlobStorageService;
            _pictureStorage = pictureStorage;
            _contentContainer = _configuration["ContentContainer"];
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AzurePictureDTO>>>GetAllPicturesFromBlobContainer()
        {
            var picturesFromAzureContainer = await
                _azureBlobStorageService.GetAllPicturesFromBlobContainer(_contentContainer);

            return Ok(picturesFromAzureContainer);

        }

        [HttpPost]
        public async Task<ActionResult> UploadImageToAzureStorage([FromForm] ImageUploadDTO partialImageData)
        {
            Stream fileStream = await _pictureStorage.CopyImageFromDataToStream(partialImageData);

            await _azureBlobStorageService.UploadImage(partialImageData, _contentContainer, fileStream);

            return Ok();
        }
    }
}