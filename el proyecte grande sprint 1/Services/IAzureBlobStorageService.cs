using el_proyecte_grande_sprint_1.Models.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace el_proyecte_grande_sprint_1.Services
{
    public interface IAzureBlobStorageService
    {
        Task<IEnumerable<AzurePictureDTO>> GetAllPicturesFromBlobContainer(string container);
        Task<Uri> UploadImage(ImageUploadDTO partialImageData, string container, Stream fileStream);
    }
}