using System;

public interface IPictureStorage {
	IEnumerable<Picture> GetAllPictures();
	void AddPicture(ref Picture picture);
	void DeletePicture(ref Picture picture);
	IEnumerable<Picture> GetAllPicturesByCategory(ref PictureCategory category);
	IEnumerable<Picture> GetAllPicturesByUser(ref User username);
	void AddNewComment(ref UUID pictureID, ref User username, ref Comment comment);
	void IncreaseViews(ref UUID pictureID);
	void IncreaseLikes(ref UUID pictureID);
	void IncreaseDownloads(ref UUID pictureID);

}
