namespace UnitTestExample.Api;

public interface ILoggedInUserService
{
    string? GetUserName();
    string[] GetUserRoles();
}