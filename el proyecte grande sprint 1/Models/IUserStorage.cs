using System;

public interface IUserStorage {
	void AddUser(ref User user);
	IEnumerable<User> GetAllUsers();
	User GetUserByUserId(ref UUID user_id);
	User GetUserByUsername(ref string username);

}
