using Azure.Storage.Blobs;
using el_proyecte_grande_sprint_1.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace el_proyecte_grande_sprint_1.Services
{
    public class AzureBlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IConfiguration _configuration;

        public AzureBlobStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
            _blobServiceClient = new BlobServiceClient(_configuration["AzureStorageConnectionString"]);
        }


        public async Task<IEnumerable<AzurePictureDTO>> GetAllPicturesFromBlobContainer(string container)
        {
            List<AzurePictureDTO> azurePictures = new List<AzurePictureDTO>();

            var blobContainerClient = _blobServiceClient.GetBlobContainerClient(container);

            await foreach (var blobItem in blobContainerClient.GetBlobsAsync())
            {
                var blobClient = blobContainerClient.GetBlobClient(blobItem.Name);
                var uri = blobClient.Uri;

                AzurePictureDTO azurePicture = new AzurePictureDTO(uri.OriginalString, blobItem.Name, blobItem.Name);
                azurePictures.Add(azurePicture);
            }

            return azurePictures;

        }

        public async Task<Uri> UploadImage(ImageUploadDTO partialImageData, string container, Stream fileStream)
        {
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient(container);

            var blobClient = blobContainerClient.GetBlobClient(partialImageData.Image.FileName);

            await using (fileStream)
            {
                var result = await blobClient.UploadAsync(fileStream, true);
            }


            return blobClient.Uri;
        }
    }
}
