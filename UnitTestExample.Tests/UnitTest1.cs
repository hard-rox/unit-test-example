using NSubstitute;
using NSubstitute.ReturnsExtensions;
using UnitTestExample.Api;

namespace UnitTestExample.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //Arrange
        var loggedInUserServiceSubstitute = Substitute.For<ILoggedInUserService>();
        loggedInUserServiceSubstitute.GetUserName()
            .Returns("John doe");
        var businessService = new BusinessService(loggedInUserServiceSubstitute);

        //Act
        var processResult = businessService.BusinessProcessOne();

        //Assert
        Assert.Equal("John doe", processResult);
    }

    [Fact]
    public void Test2()
    {
        //Arrange
        var loggedInUserServiceSubstitute = Substitute.For<ILoggedInUserService>();
        var businessService = new BusinessService(loggedInUserServiceSubstitute);
        loggedInUserServiceSubstitute.GetUserName()
            .ReturnsNull();

        //Assert
        var ex = Assert.Throws<Exception>(() =>
        {
            // Act
            var processResult = businessService.BusinessProcessOne();
        });
        Assert.Equal("User not found", ex.Message);
    }
}