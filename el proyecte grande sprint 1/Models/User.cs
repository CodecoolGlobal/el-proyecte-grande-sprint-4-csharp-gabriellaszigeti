using System;
using System.ComponentModel.DataAnnotations;
public class User {

	[Key]
	public int Id { get; set; }
	public string Email { get; set; }
	public string Username { get; set; }
	public string Password { get; set;}

	public void ChangePassword(string newPassword)
	{
		throw new System.NotImplementedException("Not implemented");
	}
}
