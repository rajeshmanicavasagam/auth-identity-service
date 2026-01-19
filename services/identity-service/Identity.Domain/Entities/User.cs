namespace Identity.Domain.Entities;

public class User
{
    public Guid Id { get; init; }
    public string Email { get; init; }
    public string PasswordHash { get; private set; }
    public DateTime CreatedAt { get; init; }

    public User(Guid id, string email, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new InvalidOperationException("Email is required");

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new InvalidOperationException("Password hash is required");

        Id = id;
        Email = email.ToLowerInvariant();
        PasswordHash = passwordHash;
        CreatedAt = DateTime.UtcNow;
    }

    public void ChangePassword(string newPasswordHash)
    {
        if (string.IsNullOrWhiteSpace(newPasswordHash))
            throw new InvalidOperationException("Password hash is required");

        PasswordHash = newPasswordHash;
    }
}
