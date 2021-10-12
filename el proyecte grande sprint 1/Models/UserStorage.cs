using System;

public class UserStorage : IUserStorage  {
	private Set<User> _users;

	public void AddUser(ref User user) {
		throw new System.NotImplementedException("Not implemented");
	}
	public IEnumerable<User> GetAllUsers() {
		throw new System.NotImplementedException("Not implemented");
	}
	public User GetUserByUserId(ref UUID user_id) {
		throw new System.NotImplementedException("Not implemented");
	}
	public User GetUserByUsername(ref string username) {
		throw new System.NotImplementedException("Not implemented");
	}

	private User user;

}
