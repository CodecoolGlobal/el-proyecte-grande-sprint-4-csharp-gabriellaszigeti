using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

public class User {

	[Key]
	public int Id { get; set; }
	public string Email { get; set; }
	public string Username { get; set; }
	public string Password { get; set;}

	public Rfc2898DeriveBytes HashPassword(string password) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void ChangePassword(string newPassword) {
		throw new System.NotImplementedException("Not implemented");
	}

}
