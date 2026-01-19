using Identity.Application.DTOs;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;

namespace Identity.Application.UseCases;

public class RegisterUserHandler
{
    private readonly IUserRepository _users;
    private readonly IPasswordHasher _hasher;

    public RegisterUserHandler(
        IUserRepository users,
        IPasswordHasher hasher)
    {
        _users = users;
        _hasher = hasher;
    }

    public async Task HandleAsync(RegisterUserRequest request)
    {
        var existing = await _users.GetByEmailAsync(request.Email);
        if (existing != null)
            throw new InvalidOperationException("User already exists");

        var hash = _hasher.Hash(request.Password);

        var user = new User(
            Guid.NewGuid(),
            request.Email,
            hash
        );

        await _users.AddAsync(user);
    }
}
