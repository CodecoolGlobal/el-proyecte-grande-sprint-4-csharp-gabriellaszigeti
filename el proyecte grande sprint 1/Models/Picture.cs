using System;
using System.Collections.Generic;

public class Picture {
	private string _name;
	private string _route;
	private UUID _id;
	private DateTime _uploadDate;
	private PictureCategory _category;
	private User _nameOfUploader;
	private List<Comment> _comments;
	private int _views;
	private int _likes;
	private int _yearTaken;
	private int _downloads;

	public void AddComment(Comment comment, User username) {
		throw new System.NotImplementedException("Not implemented");
	}

	private Comment comment;

	private PictureStorage pictureStorage;

}
