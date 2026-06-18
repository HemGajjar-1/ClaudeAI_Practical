using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Application.DependencyInjection;
using StudentManagement.Application.Interfaces;
using StudentManagement.Infrastructure.DependencyInjection;
using StudentManagement.Console.UI;

var services = new ServiceCollection();
services.AddApplicationServices();
services.AddInfrastructureServices();

await using var provider = services.BuildServiceProvider();
var studentService = provider.GetRequiredService<IStudentService>();
var menu = new StudentMenu(studentService);

await menu.RunAsync();
