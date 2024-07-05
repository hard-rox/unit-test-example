namespace UnitTestExample.Api;

public class BusinessService(ILoggedInUserService loggedInUserService)
{
    public string BusinessProcessOne()
    {
        if(loggedInUserService.GetUserName() is null)
            throw new Exception("User not found");

        return loggedInUserService.GetUserName();
    }
}