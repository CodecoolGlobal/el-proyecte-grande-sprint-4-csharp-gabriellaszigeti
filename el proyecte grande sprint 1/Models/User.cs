using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

public class User {

	[Key]
	private int Id { get; set; }

	private string Email { get; set; }
	private string Username { get; set; }
	private Rfc2898DeriveBytes Password { get; set;}

	public Rfc2898DeriveBytes HashPassword(string password) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void ChangePassword(string newPassword) {
		throw new System.NotImplementedException("Not implemented");
	}

}
