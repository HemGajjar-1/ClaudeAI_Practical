using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Application.DependencyInjection;
using StudentManagement.Application.DTOs;
using StudentManagement.Application.Interfaces;
using StudentManagement.Infrastructure.DependencyInjection;

namespace StudentManagement.Tests;

public class StudentServiceTests
{
    private static IStudentService CreateService()
    {
        var services = new ServiceCollection();
        services.AddApplicationServices();
        services.AddInfrastructureServices();
        return services.BuildServiceProvider().GetRequiredService<IStudentService>();
    }

    private static CreateStudentDTO BuildDto(
        string name = "John Doe",
        string email = "john.doe@example.com",
        double grade = 85.0) => new()
    {
        Name = name,
        Email = email,
        EnrollmentDate = new DateTime(2024, 1, 15),
        Grade = grade
    };

    // ── Test 1: Add ────────────────────────────────────────────────────────────

    [Fact]
    public async Task AddAsync_ValidStudent_StudentIsPersistedWithCorrectData()
    {
        // Arrange
        var service = CreateService();
        var dto = BuildDto();

        // Act
        await service.AddAsync(dto);
        var all = (await service.GetAllAsync()).ToList();

        // Assert
        Assert.Single(all);
        Assert.Equal(dto.Name, all[0].Name);
        Assert.Equal(dto.Email, all[0].Email);
        Assert.Equal(dto.Grade, all[0].Grade);
        Assert.Equal(dto.EnrollmentDate, all[0].EnrollmentDate);
    }

    // ── Test 2: GetAll ─────────────────────────────────────────────────────────

    [Fact]
    public async Task GetAllAsync_MultipleStudentsAdded_ReturnsAllStudents()
    {
        // Arrange
        var service = CreateService();
        await service.AddAsync(BuildDto("Alice", "alice@example.com"));
        await service.AddAsync(BuildDto("Bob", "bob@example.com"));
        await service.AddAsync(BuildDto("Carol", "carol@example.com"));

        // Act
        var result = (await service.GetAllAsync()).ToList();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Contains(result, s => s.Name == "Alice");
        Assert.Contains(result, s => s.Name == "Bob");
        Assert.Contains(result, s => s.Name == "Carol");
    }

    // ── Test 3: GetById ────────────────────────────────────────────────────────

    [Fact]
    public async Task GetByIdAsync_ExistingId_ReturnsCorrectStudent()
    {
        // Arrange
        var service = CreateService();
        await service.AddAsync(BuildDto("Diana", "diana@example.com", 72.0));
        var id = (await service.GetAllAsync()).First().Id;

        // Act
        var student = await service.GetByIdAsync(id);

        // Assert
        Assert.NotNull(student);
        Assert.Equal("Diana", student.Name);
        Assert.Equal("diana@example.com", student.Email);
        Assert.Equal(72.0, student.Grade);
    }

    [Fact]
    public async Task GetByIdAsync_NonExistentId_ReturnsNull()
    {
        // Arrange
        var service = CreateService();

        // Act
        var result = await service.GetByIdAsync(999);

        // Assert
        Assert.Null(result);
    }

    // ── Test 4: UpdateGrade ────────────────────────────────────────────────────

    [Fact]
    public async Task UpdateGradeAsync_ExistingStudent_GradeIsUpdatedCorrectly()
    {
        // Arrange
        var service = CreateService();
        await service.AddAsync(BuildDto(grade: 50.0));
        var id = (await service.GetAllAsync()).First().Id;
        const double newGrade = 98.5;

        // Act
        await service.UpdateGradeAsync(id, newGrade);
        var updated = await service.GetByIdAsync(id);

        // Assert
        Assert.NotNull(updated);
        Assert.Equal(newGrade, updated.Grade);
    }

    [Fact]
    public async Task UpdateGradeAsync_NonExistentStudent_ThrowsKeyNotFoundException()
    {
        // Arrange
        var service = CreateService();

        // Act & Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(
            () => service.UpdateGradeAsync(999, 80.0));
    }

    // ── Test 5: Delete ─────────────────────────────────────────────────────────

    [Fact]
    public async Task DeleteAsync_ExistingStudent_StudentIsRemovedFromStore()
    {
        // Arrange
        var service = CreateService();
        await service.AddAsync(BuildDto("Eve", "eve@example.com"));
        await service.AddAsync(BuildDto("Frank", "frank@example.com"));
        var all = (await service.GetAllAsync()).ToList();
        var idToDelete = all.First(s => s.Name == "Eve").Id;

        // Act
        await service.DeleteAsync(idToDelete);
        var remaining = (await service.GetAllAsync()).ToList();

        // Assert
        Assert.Single(remaining);
        Assert.DoesNotContain(remaining, s => s.Name == "Eve");
        Assert.Contains(remaining, s => s.Name == "Frank");
    }
}
