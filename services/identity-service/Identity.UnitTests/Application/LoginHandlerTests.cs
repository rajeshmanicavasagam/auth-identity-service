using Identity.Application.DTOs;
using Identity.Application.UseCases;
using Identity.Domain.Entities;
using Identity.UnitTests.Fakes;
using Xunit;

namespace Identity.UnitTests.Application;

public class LoginHandlerTests
{
    [Fact]
    public async Task Login_returns_token_for_valid_credentials()
    {
        var repo = new FakeUserRepository();
        var hasher = new FakePasswordHasher();
        var tokens = new FakeTokenService();

        var user = new User(
            Guid.NewGuid(),
            "user@test.com",
            hasher.Hash("Password123")
        );

        await repo.AddAsync(user);

        var handler = new LoginHandler(repo, hasher, tokens);

        var response = await handler.HandleAsync(
            new LoginRequest("user@test.com", "Password123")
        );

        Assert.Equal("FAKE_JWT_TOKEN", response.AccessToken);
    }

    [Fact]
    public async Task Login_fails_for_invalid_password()
    {
        var repo = new FakeUserRepository();
        var hasher = new FakePasswordHasher();
        var tokens = new FakeTokenService();

        var user = new User(
            Guid.NewGuid(),
            "user@test.com",
            hasher.Hash("Password123")
        );

        await repo.AddAsync(user);

        var handler = new LoginHandler(repo, hasher, tokens);

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            handler.HandleAsync(
                new LoginRequest("user@test.com", "WrongPassword")
            )
        );
    }
}
