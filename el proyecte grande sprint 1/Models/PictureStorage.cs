using System;

public class PictureStorage : IPictureStorage  {
	private Set<Picture> _pictures;

	public IEnumerable<Picture> GetAllPictures() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AddPicture(ref Picture picture) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void DeletePicture(ref Picture picture) {
		throw new System.NotImplementedException("Not implemented");
	}
	public IEnumerable<Picture> GetAllPicturesByCategory(ref PictureCategory category) {
		throw new System.NotImplementedException("Not implemented");
	}
	public IEnumerable<Picture> GetAllPicturesByUser(ref User username) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AddNewComment(ref UUID pictureID, ref User username, ref Comment comment) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void IncreaseViews(ref UUID pictureID) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void IncreaseLikes(ref UUID pictureID) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void IncreaseDownloads(ref UUID pictureID) {
		throw new System.NotImplementedException("Not implemented");
	}

	private Picture picture;

	private PictureCategory pictureCategory;

}
