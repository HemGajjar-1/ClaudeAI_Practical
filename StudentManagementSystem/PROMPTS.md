# PROMPTS.md

## Step 1 - Domain Setup
Role: Senior .NET Architect  
Context: Clean Architecture Student Management System  
Task: Create Domain layer with Student entity  
Format: C# class only, no explanation  
Constraints: Id int required unique, Name string max 100 required, Email valid required, EnrollmentDate required, Grade 0–100, no logic, no dependencies  

---

## Step 2 - Application Layer
Role: Senior .NET Architect  
Context: Domain layer ready  
Task: Create IStudentService + StudentService with Add, GetAll, GetById, UpdateGrade, Delete  
Format: C# only  
Constraints: Async required, only Domain dependency, no Infrastructure, no List<Student>, SOLID, DI constructor only, no static  

---

## Step 3 - Infrastructure Layer
Role: Senior .NET Architect  
Context: Domain + Application ready  
Task: Create IGenericRepository + GenericRepository using in-memory storage  
Format: C# only  
Constraints: Async required, Repository pattern, CRUD support, no business logic, only Infrastructure can use List<Student>, no static classes  

---

## Step 4 - Unit of Work + DI
Role: Senior .NET Architect  
Context: Repository layer implemented  
Task: Create IUnitOfWork + UnitOfWork and wire repositories  
Format: C# only  
Constraints: Must expose repositories via UoW, async support, DI only, no service locator, no business logic  

---

## Step 5 - Console App
Role: Senior .NET Architect  
Context: Backend layers ready  
Task: Build menu-driven console UI and wire DI  
Format: C# only  
Constraints: No business logic, only UI + service calls, menu for CRUD operations, strict layering  

---

## Step 6 - Unit Tests
Role: Senior .NET Architect  
Context: Application layer ready  
Task: Write xUnit tests for StudentService (5 tests minimum)  
Format: C# test code only  
Constraints: Async tests, Arrange-Act-Assert, no console/db, Application layer only, isolated tests  

---

## Step 7 - Final Review
Role: Senior .NET Architect  
Context: Full system completed  
Task: Validate architecture, fix violations if any  
Format: C# fixes only  
Constraints: Must enforce Clean Architecture, no boundary violations, minimal fixes only  