namespace Identity.Application.DTOs;

public record RegisterUserRequest(
    string Email,
    string Password
);
