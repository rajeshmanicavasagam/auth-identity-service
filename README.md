![CI](https://github.com/RajeshManicavasagam/auth-identity-service/actions/workflows/ci.yml/badge.svg)

# Auth Identity Service (.NET 8)

This repository provides a **standalone identity and authentication service**
implemented in **.NET 8**, following **Clean Architecture** and
security-aware backend design principles.

The service is intentionally scoped to demonstrate **authentication boundaries,
password handling, JWT issuance, testability, and CI discipline**.

---

## 🧱 Architecture Overview

The service follows Clean Architecture:

API → Application → Domain
↓
Infrastructure


- **Domain**: User aggregate and security invariants
- **Application**: Authentication use cases (register, login)
- **Infrastructure**: Password hashing, token generation, persistence
- **API**: HTTP interface

---

## 🔐 Responsibilities

- User registration
- User authentication
- Password hashing (BCrypt)
- JWT access token generation
- Clear separation of security concerns

This service acts as an **authentication boundary** for other backend services.

---

## 👤 Domain Model

### User Aggregate
- Id
- Email (normalized)
- PasswordHash
- CreatedAt

### Rules enforced in the domain:
- Email must be present and normalized
- Passwords are **never** stored or handled in plaintext
- Security-sensitive logic is not exposed to controllers

---

## 🔑 Authentication Flow

1. User registers with email and password
2. Password is hashed in the infrastructure layer
3. User logs in with credentials
4. Credentials are verified
5. JWT access token is issued

The application layer orchestrates the flow without
knowing hashing or token implementation details.

---

## 🛠️ Technology Stack

- .NET 8 (LTS)
- ASP.NET Core Web API
- Clean Architecture
- BCrypt for password hashing
- JWT (HMAC-SHA256)
- xUnit for unit testing
- GitHub Actions for CI

---

## 🧪 Testing Strategy

Unit tests focus on:
- Register and login use cases
- Credential validation behavior
- Failure cases (duplicate users, invalid credentials)

Tests avoid HTTP, JWT parsing, and framework dependencies.

---

## 🔁 CI Pipeline

A GitHub Actions pipeline ensures:
- Dependency restore
- Build validation
- Execution of all unit tests

Defined in:

.github/workflows/ci.yml


---

## ▶️ Running Locally

```bash
dotnet run --project services/identity-service/Identity.API

Swagger UI:
http://localhost:{port}/swagger

🔒 Security Notes

⚠️ This project uses a hardcoded JWT signing key for demonstration purposes.
In production systems, secrets must be stored securely (environment variables,
Key Vaults, or secret managers).

Authentication tokens are stateless and short-lived.

🚀 Future Improvements

External identity provider integration

Refresh tokens

Role / claim-based authorization

Persistent user store (database)

Centralized secret management

📌 Scope Disclaimer

This service is designed to demonstrate backend authentication architecture
rather than a full OAuth or IAM solution.
