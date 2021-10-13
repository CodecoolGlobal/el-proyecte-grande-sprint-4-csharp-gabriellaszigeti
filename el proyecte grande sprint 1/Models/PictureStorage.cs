using System;
using System.Collections.Generic;

public class PictureStorage : IPictureStorage  {
	private HashSet<Picture> _pictures;

	public IEnumerable<Picture> GetAllPictures() {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AddPicture(Picture picture) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void DeletePicture(Picture picture) {
		throw new System.NotImplementedException("Not implemented");
	}
	public IEnumerable<Picture> GetAllPicturesByCategory(PictureCategory category) {
		throw new System.NotImplementedException("Not implemented");
	}
	public IEnumerable<Picture> GetAllPicturesByUser(User username) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void AddNewComment(Guid pictureID,User username, Comment comment) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void IncreaseViews(Guid pictureID) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void IncreaseLikes(Guid pictureID) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void IncreaseDownloads(Guid pictureID) {
		throw new System.NotImplementedException("Not implemented");
	}
}
