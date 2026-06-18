Project: Student Management System (Clean Architecture + Repository Pattern)

Project Layers
- Domain
  - Entities, enums, value objects only
  - No external dependencies

- Application
  - Business logic (services / use cases)
  - Interfaces (repositories, services)
  - DTOs

- Infrastructure
  - Repository implementations
  - Generic Repository implementation
  - Unit of Work implementation
  - In-memory storage (List<Student>)

- Console
  - Entry point (Program.cs)
  - Menu-driven UI only
  - No business logic

- Tests
  - xUnit tests for Application layer

Core Rules (STRICT)
- Domain must be pure and independent
- Domain must NOT depend on any other layer
- Application must NOT depend on Infrastructure
- Console can depend on Application + Infrastructure only for wiring
- Dependency flow must always be inward

Architecture Patterns (MANDATORY)
- Repository Pattern
- Generic Repository
- Unit of Work
- Dependency Injection (constructor injection only)

Repository Rules
- No direct access to List<Student> outside Infrastructure
- All data access must go through repositories
- Use IGenericRepository<TEntity>
- Specific repositories only if required

Unit of Work Rules
- Central coordinator for repositories
- Manages repository lifecycle access
- Exposes repositories through a single interface

Async Rules
- All repository methods must return Task or Task<T>
- Even in-memory operations must follow async signatures

Coding Rules
- Follow SOLID principles strictly
- Keep classes small and single responsibility
- Prefer composition over inheritance
- No static classes for services
- No service locator pattern
- Avoid unnecessary abstraction

Naming Conventions
- Interfaces: IName (e.g., IStudentService)
- Classes: PascalCase
- Methods: PascalCase
- Private fields: _camelCase
- DTOs: suffix DTO
- Services: suffix Service
- Repositories: suffix Repository

Domain Rules
- Student entity contains:
  - Id
  - Name
  - Email
  - EnrollmentDate
  - Grade

Application Rules
- Contains services + interfaces + DTOs
- Must not reference Infrastructure

Infrastructure Rules
- Implements repositories
- Uses in-memory List<Student>
- Implements GenericRepository and UnitOfWork

Console Rules
- Only UI logic (menu + input/output)
- Must call Application services only
- No business logic allowed

Testing Rules
- Use xUnit
- Minimum 5 tests for StudentService
- Cover:
  - Add student
  - Get all students
  - Get by ID
  - Update grade
  - Delete student

Output Rules
- Generate clean production-ready C# code
- No explanations unless asked
- No architecture violations
- Prefer simplicity over over-engineering

Behavior Rule
- Act as a strict senior .NET architect
- Reject any design that breaks layered architecture
- Always enforce proper separation of concerns