using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;  // Ensure this is included
using WebApplication2.Models;
using Xunit;

namespace WebApplication2.Test
{
    public class StudentManagementTests
    {
        // Helper method to get an in-memory database context
        private WebApplication2Context GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<WebApplication2Context>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var context = new WebApplication2Context(options);
            return context;
        }

        [Fact]
        public async Task Create_ValidStudent_StudentIsAdded()
        {
            // Arrange: Set up the in-memory database
            var context = GetInMemoryDbContext();

            var student = new StudentManagement
            {
                student_id = 1,
                name = "John Doe",
                email = "john.doe@example.com",
                password = "password123",
                phone = "123-456-7890"
            };

            // Act: Add student to the in-memory database
            context.StudentManagement.Add(student);
            await context.SaveChangesAsync();

            // Assert: Verify that the student is added to the database
            var studentInDb = await context.StudentManagement.FindAsync(1);
            Assert.NotNull(studentInDb);
            Assert.Equal("John Doe", studentInDb.name);
            Assert.Equal("john.doe@example.com", studentInDb.email);
            Assert.Equal("password123", studentInDb.password);
            Assert.Equal("123-456-7890", studentInDb.phone);
        }

        [Fact]
        public async Task Create_InvalidStudent_ThrowsValidationError()
        {
            // Arrange: Set up the in-memory database
            var context = GetInMemoryDbContext();

            var invalidStudent = new StudentManagement
            {
                student_id = 2,
                name = "",  // Invalid: Empty name, should trigger validation error
                email = "invalid.email@example.com",
                password = "password123",
                phone = "123-456-7890"
            };

            // Act & Assert: Try adding invalid student and expect a validation error
            context.StudentManagement.Add(invalidStudent);
            var exception = await Assert.ThrowsAsync<DbUpdateException>(async () => await context.SaveChangesAsync());

            // Assert that no student with id 2 exists
            var studentInDb = await context.StudentManagement.FindAsync(2);
            Assert.Null(studentInDb);
        }
    }
}
