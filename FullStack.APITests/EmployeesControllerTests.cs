using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStack.API.Controllers;
using FullStack.API.Data;
using FullStack.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FullStack.API.Tests
{
    public class EmployeesControllerTests
    {
        [Fact]
        public async Task GetAllEmployees_ReturnsEmployeeInformation()
        {
            // Arrange - Setting up in-memory database
            var options = new DbContextOptionsBuilder<FullStackDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            // Seed the database with test data
            using (var context = new FullStackDbContext(options))
            {
                context.Employees.Add(new Employee { Id = Guid.NewGuid(), Name = "John Doe", Email = "john.doe@example.com", Phone = 123456789, Salary = 60000, Department = "HR" });
                context.Employees.Add(new Employee { Id = Guid.NewGuid(), Name = "Jane Doe", Email = "jane.doe@example.com", Phone = 987654321, Salary = 65000, Department = "Finance" });
                await context.SaveChangesAsync();
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new FullStackDbContext(options))
            {
                var controller = new EmployeesController(context);

                // Act
                var result = await controller.GetAllEmployees();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var employees = Assert.IsAssignableFrom<IEnumerable<Employee>>(okResult.Value);

                // Checking if NotNull is returned
                Assert.NotNull(employees);

                // Checking if information of 2 employees is returned
                Assert.Equal(2, employees.Count());
            }
        }

        [Fact]
        public async Task AddEmployee_ReturnsOkResult_WithCreatedEmployee()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FullStackDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database_Add")
                .Options;

            var newEmployee = new Employee { Name = "John Smith", Email = "john.smith@example.com", Phone = 123456789, Salary = 50000, Department = "IT" };

            // Act & Assert
            using (var context = new FullStackDbContext(options))
            {
                var controller = new EmployeesController(context);
                var result = await controller.AddEmployee(newEmployee);

                var okResult = Assert.IsType<OkObjectResult>(result);
                var createdEmployee = Assert.IsType<Employee>(okResult.Value);

                Assert.Equal(newEmployee.Name, createdEmployee.Name);
                Assert.Equal(newEmployee.Email, createdEmployee.Email);
            }
        }

        [Fact]
        public async Task GetEmployee_ReturnsNotFound_WhenEmployeeDoesNotExist()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FullStackDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database_Get")
                .Options;

            using (var context = new FullStackDbContext(options))
            {
                var controller = new EmployeesController(context);

                // Act
                var result = await controller.GetEmployee(Guid.NewGuid());

                // Assert
                Assert.IsType<NotFoundResult>(result);
            }
        }

        [Fact]
        public async Task GetEmployee_ReturnsOkResult_WithEmployee()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FullStackDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database_Get_Existing")
                .Options;

            var employee = new Employee { Id = Guid.NewGuid(), Name = "John Smith", Email = "john.smith@example.com", Phone = 123456789, Salary = 50000, Department = "IT" };

            using (var context = new FullStackDbContext(options))
            {
                context.Employees.Add(employee);
                await context.SaveChangesAsync();
            }

            using (var context = new FullStackDbContext(options))
            {
                var controller = new EmployeesController(context);

                // Act
                var result = await controller.GetEmployee(employee.Id);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var returnedEmployee = Assert.IsType<Employee>(okResult.Value);

                Assert.Equal(employee.Id, returnedEmployee.Id);
            }
        }

        [Fact]
        public async Task UpdateEmployee_ReturnsNotFound_WhenEmployeeDoesNotExist()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FullStackDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database_Update")
                .Options;

            var updateEmployeeRequest = new Employee { Name = "Updated Name", Email = "updated.email@example.com", Phone = 987654321, Salary = 55000, Department = "IT" };

            using (var context = new FullStackDbContext(options))
            {
                var controller = new EmployeesController(context);

                // Act
                var result = await controller.UpdateEmployee(Guid.NewGuid(), updateEmployeeRequest);

                // Assert
                Assert.IsType<NotFoundResult>(result);
            }
        }

        [Fact]
        public async Task UpdateEmployee_ReturnsOkResult_WithUpdatedEmployee()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FullStackDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database_Update_Existing")
                .Options;

            var employee = new Employee { Id = Guid.NewGuid(), Name = "John Smith", Email = "john.smith@example.com", Phone = 123456789, Salary = 50000, Department = "IT" };

            using (var context = new FullStackDbContext(options))
            {
                context.Employees.Add(employee);
                await context.SaveChangesAsync();
            }

            var updateEmployeeRequest = new Employee { Name = "Updated Name", Email = "updated.email@example.com", Phone = 987654321, Salary = 55000, Department = "IT" };

            using (var context = new FullStackDbContext(options))
            {
                var controller = new EmployeesController(context);

                // Act
                var result = await controller.UpdateEmployee(employee.Id, updateEmployeeRequest);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var updatedEmployee = Assert.IsType<Employee>(okResult.Value);

                Assert.Equal(updateEmployeeRequest.Name, updatedEmployee.Name);
                Assert.Equal(updateEmployeeRequest.Email, updatedEmployee.Email);
            }
        }

        [Fact]
        public async Task DeleteEmployee_ReturnsNotFound_WhenEmployeeDoesNotExist()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FullStackDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database_Delete")
                .Options;

            using (var context = new FullStackDbContext(options))
            {
                var controller = new EmployeesController(context);

                // Act
                var result = await controller.DeleteEmployee(Guid.NewGuid());

                // Assert
                Assert.IsType<NotFoundResult>(result);
            }
        }

        [Fact]
        public async Task DeleteEmployee_ReturnsOkResult_WithDeletedEmployee()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FullStackDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database_Delete_Existing")
                .Options;

            var employee = new Employee { Id = Guid.NewGuid(), Name = "John Smith", Email = "john.smith@example.com", Phone = 123456789, Salary = 50000, Department = "IT" };

            using (var context = new FullStackDbContext(options))
            {
                context.Employees.Add(employee);
                await context.SaveChangesAsync();
            }

            using (var context = new FullStackDbContext(options))
            {
                var controller = new EmployeesController(context);

                // Act
                var result = await controller.DeleteEmployee(employee.Id);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var deletedEmployee = Assert.IsType<Employee>(okResult.Value);

                Assert.Equal(employee.Id, deletedEmployee.Id);
            }
        }
    }
}
