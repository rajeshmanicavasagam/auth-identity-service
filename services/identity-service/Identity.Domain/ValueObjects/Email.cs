namespace Identity.Domain.ValueObjects;

public record Email
{
    public string Value { get; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !value.Contains('@'))
            throw new InvalidOperationException("Invalid email address");

        Value = value.ToLowerInvariant();
    }

    public override string ToString() => Value;
}
