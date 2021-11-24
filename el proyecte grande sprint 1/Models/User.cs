using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

public class User {

	[Key]
	public int Id { get; set; }
	public string Email { get; set; }
	public string Username { get; set; }
	public string Password { get; set;}

	public string HashPassword(string password) {

		byte[] salt;
		new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

		var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
		byte[] hash = pbkdf2.GetBytes(20);

		byte[] hashBytes = new byte[36];
		Array.Copy(salt, 0, hashBytes, 0, 16);
		Array.Copy(hash, 0, hashBytes, 16, 20);

		return Convert.ToBase64String(hashBytes);
	}
	public void ChangePassword(string newPassword) {
		throw new System.NotImplementedException("Not implemented");
	}

}
