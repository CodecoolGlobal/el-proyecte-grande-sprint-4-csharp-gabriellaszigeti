using System;

public class User {
	private string _username;
	private Rfc2898DeriveBytes _password;
	private UUID _userId;

	public Rfc2898DeriveBytes HashPassword(ref string password) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void ChangePassword(ref string newPassword) {
		throw new System.NotImplementedException("Not implemented");
	}

	private Comment comment;

	private UserStorage userStorage;

}
