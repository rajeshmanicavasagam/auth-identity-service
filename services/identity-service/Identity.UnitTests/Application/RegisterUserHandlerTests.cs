using Identity.Application.DTOs;
using Identity.Application.UseCases;
using Identity.UnitTests.Fakes;
using Xunit;

namespace Identity.UnitTests.Application;

public class RegisterUserHandlerTests
{
    [Fact]
    public async Task Register_creates_new_user()
    {
        var repo = new FakeUserRepository();
        var hasher = new FakePasswordHasher();
        var handler = new RegisterUserHandler(repo, hasher);

        var request = new RegisterUserRequest(
            "user@test.com",
            "Password123"
        );

        await handler.HandleAsync(request);

        Assert.Single(repo.Users);
        Assert.Equal("user@test.com", repo.Users[0].Email);
    }

    [Fact]
    public async Task Register_fails_if_user_exists()
    {
        var repo = new FakeUserRepository();
        var hasher = new FakePasswordHasher();
        var handler = new RegisterUserHandler(repo, hasher);

        await handler.HandleAsync(
            new RegisterUserRequest("user@test.com", "Password123")
        );

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            handler.HandleAsync(
                new RegisterUserRequest("user@test.com", "Password123")
            )
        );
    }
}
