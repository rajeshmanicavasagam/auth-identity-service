using Identity.Application.DTOs;
using Identity.Application.Interfaces;

namespace Identity.Application.UseCases;

public class LoginHandler
{
    private readonly IUserRepository _users;
    private readonly IPasswordHasher _hasher;
    private readonly ITokenService _tokens;

    public LoginHandler(
        IUserRepository users,
        IPasswordHasher hasher,
        ITokenService tokens)
    {
        _users = users;
        _hasher = hasher;
        _tokens = tokens;
    }

    public async Task<AuthResponse> HandleAsync(LoginRequest request)
    {
        var user = await _users.GetByEmailAsync(request.Email);
        if (user == null)
            throw new InvalidOperationException("Invalid credentials");

        if (!_hasher.Verify(request.Password, user.PasswordHash))
            throw new InvalidOperationException("Invalid credentials");

        var token = _tokens.GenerateToken(user);
        return new AuthResponse(token);
    }
}
