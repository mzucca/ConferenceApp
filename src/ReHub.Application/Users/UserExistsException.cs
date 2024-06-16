namespace ReHub.Application.Users;

public class UserExistsException : Exception
{
    public UserExistsException() { }
    public UserExistsException(string name) => UserName = name;
    public string UserName { get; set; }
}
