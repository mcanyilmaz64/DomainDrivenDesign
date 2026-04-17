# Domain-Driven Design — E-Commerce Backend

A backend REST API built with **ASP.NET Core (.NET 8)** following **Domain-Driven Design (DDD)** principles and **Clean Architecture**. This project demonstrates practical application of DDD tactical patterns — Aggregates, Value Objects, Domain Events, Repository Pattern — combined with CQRS via MediatR and Entity Framework Core for persistence.

---

## Tech Stack

| Layer | Technology |
|---|---|
| Framework | .NET 8 / ASP.NET Core Web API |
| ORM | Entity Framework Core 8 (SQL Server) |
| CQRS / Mediator | MediatR 14 |
| Documentation | Swagger / OpenAPI |
| Language | C# 12 |

---

## Architecture

The solution is structured around **Clean Architecture** with four layers:

```
DomainDrivenDesign.sln
├── DomainDrivenDesign.Domain          # Aggregates, Value Objects, Domain Events, Repository Interfaces
├── DomainDrivenDesign.Application     # Commands, Queries, Handlers (CQRS via MediatR)
├── DomainDrivenDesign.Infrastructure  # EF Core DbContext, Repository Implementations, DI Registration
└── DomainDrivenDesign.WebApi          # ASP.NET Core Controllers, Middleware, Swagger
```

**Dependency rule:** each layer depends only inward — WebApi → Application → Domain. Infrastructure depends on Domain only.

---

## Domain Model

### Aggregates

| Aggregate | Child Entities | Value Objects |
|---|---|---|
| `User` | — | `Name`, `Email`, `Password`, `Address` |
| `Order` | `OrderLine` | `Money`, `Currency` |
| `Product` | — | `Name`, `Money`, `Currency` |
| `Category` | — | `Name` |

### Value Objects

- **`Money`** — Immutable amount + currency pair. Supports `+` operator with currency validation.
- **`Currency`** — Predefined currencies (`USD`, `TRY`) with factory method `FromCode()`.
- **`Name`** — Minimum 3 characters enforced in constructor.
- **`Email`** — Requires `@` symbol, validated on creation.
- **`Address`** — Country, City, Street, PostalCode as an owned value object.

### Domain Events

| Event | Handler |
|---|---|
| `OrderDomainEvent` | `SendOrderMailEvent`, `SendOrderSmsEvent` |
| `UserDomainEvent` | `SendUserMailEvent` |

---

## Patterns & Principles

- **Domain-Driven Design** — Aggregates, Value Objects, Domain Events, Ubiquitous Language
- **Clean Architecture** — Strict layer separation, dependency inversion
- **CQRS** — Commands and Queries separated, dispatched via MediatR
- **Repository Pattern** — One repository interface per aggregate root
- **Unit of Work** — `IUnitOfWork` / `ApplicationDbContext` for transactional consistency
- **Factory Method** — `User.CreateUser()` encapsulates complex object creation
- **EF Core Owned Entities** — Value objects persisted via `OwnsOne()` and `HasConversion()`

---

## API Endpoints

| Method | Route | Description |
|---|---|---|
| POST | `/api/orders/create` | Create a new order |
| POST | `/api/orders/getall` | Retrieve all orders |
| POST | `/api/users/create` | Create a new user |
| POST | `/api/users/getall` | Retrieve all users |
| POST | `/api/products/create` | Create a new product |
| POST | `/api/products/getall` | Retrieve all products |
| POST | `/api/categories/create` | Create a new category |
| POST | `/api/categories/getall` | Retrieve all categories |

Swagger UI is available at `/swagger` when running in Development mode.

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server or SQL Server LocalDB

### Run

```bash
# Clone the repo
git clone https://github.com/<your-username>/DomainDrivenDesign.git
cd DomainDrivenDesign

# Apply database migrations
dotnet ef database update --project DomainDrivenDesign.Infrastructure --startup-project DomainDrivenDesign.WebApi

# Run the API
dotnet run --project DomainDrivenDesign.WebApi
```

Open `https://localhost:<port>/swagger` to explore the API.

---

## Project Structure (Key Files)

```
DomainDrivenDesign.Domain/
├── Entities/
│   ├── OrderAggregate/       # Order, OrderLine, OrderStatusEnum, CreateOrderDto
│   ├── UserAggregate/        # User, domain events
│   ├── ProductAggregate/     # Product
│   └── CategoryAggregate/    # Category
├── ValueObjects/             # Money, Currency, Name, Email, Password, Address
└── Repositories/             # IOrderRepository, IUserRepository, ...

DomainDrivenDesign.Application/
├── Features/Orders/          # CreateOrderCommand, GetAllOrderQuery + handlers
├── Features/Users/           # CreateUserCommand, GetAllUserQuery + handlers
├── Features/Products/        # CreateProductCommand, GetAllProductQuery + handlers
└── Features/Categories/      # CreateCategoryCommand, GetAllCategoryQuery + handlers

DomainDrivenDesign.Infrastructure/
├── Context/                  # ApplicationDbContext (EF Core, IUnitOfWork)
├── Repositories/             # Concrete repository implementations
└── DependencyInjection/      # AddInfrastructure() extension method

DomainDrivenDesign.WebApi/
├── Controllers/              # OrderController, UserController, ProductController, CategoryController
└── Program.cs                # Service registration, middleware pipeline
```

---

## License

MIT
