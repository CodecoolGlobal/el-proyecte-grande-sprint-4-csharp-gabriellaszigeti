using System;
using System.Collections.Generic;
using System.IO;

public class PictureStorage : IPictureStorage  {
	private HashSet<Picture> _pictures;
	private DirectoryInfo _directoryInfo;
	Random random = new Random();
	public const int MinYearTaken = 1826;
	public const int MaxYearTaken = 2021;
	public IEnumerable<Picture> Pictures { get { return _pictures; } }

	public PictureStorage()
	{
		_pictures = new HashSet<Picture>();
		_directoryInfo = new DirectoryInfo("C:\\");
		Seed();
	}

	private void Seed()
	{
		string path = Directory.GetCurrentDirectory() + @"\Images\categories";
		string[] subdirectories = Directory.GetDirectories(path);
		foreach (var directory in subdirectories)
		{
			foreach (var file in Directory.GetFiles(directory))
			{
				var randomYear = random.Next(MinYearTaken, MaxYearTaken);
				string category = Path.GetFileName(directory).ToUpper();
				string filename = Path.GetFileName(file);
				var enumValues = Enum.GetValues(typeof(PictureCategory));
				PictureCategory enumType = (PictureCategory)Enum.Parse(typeof(PictureCategory), category);  // Animal.Dog
				Picture picture = new Picture(filename, Path.GetDirectoryName(file), Guid.NewGuid(), GenerateDate(), enumType, new User(), randomYear);
				_pictures.Add(picture);
			}
		}
	}

	public string GenerateDate()
	{
		string year = DateTime.Now.Year.ToString();
		string month = DateTime.Now.Month.ToString();
		string day = DateTime.Now.Day.ToString();
		return $"{year}-{month}-{day}";
	}

	public IEnumerable<Picture> GetAllPictures() {
		return Pictures;
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
