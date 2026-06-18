# Student Management System (Clean Architecture + Repository Pattern)

A C# console-based Student Management System built using Clean Architecture principles with Repository Pattern, Generic Repository, Unit of Work, Dependency Injection, and xUnit testing.

---

## Overview

This project demonstrates a layered enterprise-style architecture using in-memory storage (no database). It focuses on clean separation of concerns, strong testability, and maintainable design.

---

## Features

- Add Student
- Get All Students
- Get Student By ID
- Update Student Grade
- Delete Student
- Console-based menu system
- In-memory data storage

## Layers

### Domain

- Core entity: `Student`
- No external dependencies
- No business logic outside entity rules

---

### Application

- Business logic layer
- `StudentService` + interfaces
- DTOs (if needed)
- Depends only on Domain layer

---

### Infrastructure

- Generic Repository implementation
- Unit of Work implementation
- In-memory storage
- Repository implementations

---

### Console

- Entry point (`Program.cs`)
- Menu-driven UI
- Dependency Injection setup
- No business logic

---

### Tests

- xUnit test project
- Tests Application layer only
- Uses in-memory implementations

---

## Design Patterns

- Repository Pattern
- Generic Repository Pattern
- Unit of Work Pattern
- Dependency Injection
- Service Layer Pattern

---

## Student Entity Rules

- **Id**: int (required, unique)
- **Name**: string (required, max 100)
- **Email**: string (required, valid format)
- **EnrollmentDate**: DateTime (required)
- **Grade**: double (0–100)

---

## Testing

Minimum test coverage includes:

- Add Student
- Get All Students
- Get Student By ID
- Update Student Grade
- Delete Student

---

## Principles Followed

- Clean Architecture (strict layering)
- SOLID principles
- Dependency inversion
- Async programming (Task-based)
- No direct data access outside Infrastructure
- No business logic in Console layer
- Constructor-based Dependency Injection only

---

## Tech Stack

- C# (.NET)
- xUnit
- Microsoft Dependency Injection
- In-memory collections

---

## Purpose

This project is designed for learning:

- Real-world architecture structure
- Enterprise-level design patterns
- Layered application development
- Unit testing practices
- Dependency management in .NET
