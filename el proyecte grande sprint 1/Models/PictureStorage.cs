using System;
using System.Collections.Generic;
using System.IO;

public class PictureStorage : IPictureStorage  {
	private HashSet<Picture> _pictures;
	private DirectoryInfo _directoryInfo;
	Random random = new Random();
	public const int MinYearTaken = 1826;
	public const int MaxYearTaken = 2021;

	public PictureStorage()
	{
		_pictures = new HashSet<Picture>();
		_directoryInfo = new DirectoryInfo("C:\\");
		Seed();
	}

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
