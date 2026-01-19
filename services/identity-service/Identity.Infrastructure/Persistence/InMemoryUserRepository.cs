using Identity.Application.Interfaces;
using Identity.Domain.Entities;

namespace Identity.Infrastructure.Persistence;

public class InMemoryUserRepository : IUserRepository
{
    private static readonly List<User> Users = [];

    public Task<User?> GetByEmailAsync(string email)
    {
        var user = Users.SingleOrDefault(
            u => u.Email == email.ToLowerInvariant()
        );
        return Task.FromResult(user);
    }

    public Task AddAsync(User user)
    {
        Users.Add(user);
        return Task.CompletedTask;
    }
}
