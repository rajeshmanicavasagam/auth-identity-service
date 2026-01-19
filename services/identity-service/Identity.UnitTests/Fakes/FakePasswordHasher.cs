using Identity.Application.Interfaces;

namespace Identity.UnitTests.Fakes;

public class FakePasswordHasher : IPasswordHasher
{
    public string Hash(string password)
        => $"HASHED_{password}";

    public bool Verify(string password, string passwordHash)
        => passwordHash == $"HASHED_{password}";
}
