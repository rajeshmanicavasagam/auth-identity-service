using Identity.Application.Interfaces;
using Identity.Domain.Entities;

namespace Identity.UnitTests.Fakes;

public class FakeTokenService : ITokenService
{
    public string GenerateToken(User user)
        => "FAKE_JWT_TOKEN";
}
