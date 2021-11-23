using el_proyecte_grande_sprint_1.Models.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public interface IPictureStorage
{
    IEnumerable<Picture> Pictures { get; }

    void AddNewComment(Guid pictureID, User username, Comment comment);
    void AddPicture(Picture picture);
    Task<Stream> CopyImageFromDataToStream(ImageUploadDTO partialImageData);
    void DeletePicture(Picture picture);
    string GenerateDate();
    IEnumerable<Picture> GetAllPictures();
    IEnumerable<Picture> GetAllPicturesByCategory(PictureCategory category);
    IEnumerable<Picture> GetAllPicturesByUser(User username);
    Picture GetPictureById(Guid id);
    void IncreaseDownloads(Guid pictureID);
    void IncreaseLikes(Guid pictureID);
    void IncreaseViews(Guid pictureID);
}