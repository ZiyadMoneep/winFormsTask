using System;
using Xunit;
using Xunit.Abstractions;
using WinFormsAppobTask.Services;
using WinFormsAppobTask.Models;

namespace WinFormsAppobTask.Tests.UnitTests
{
    public class AuthenticationServiceTests : IDisposable
    {
        private readonly ITestOutputHelper _output;

        public AuthenticationServiceTests(ITestOutputHelper output)
        {
            _output = output;
            // Clear Users list to ensure tests are independent
            UserDataStore.Users.Clear();
        }

        #region RegisterUser Tests

        [Fact]
        public void RegisterUser_ValidData_ReturnsSuccess()
        {
      
            string name = "John Doe";
            string email = "validuser@example.com";
            string password = "ValidPassword123!";
            string confirmPassword = password;

   
            var result = new RegistrationService().RegisterUser(name, email, password, confirmPassword);

            // Output result
            _output.WriteLine($"RegisterUser_ValidData_ReturnsSuccess: {result.Message}");

            // Assert
            Assert.True(result.Success);
            Assert.Single(UserDataStore.Users); // User should be registered
            Assert.Equal(email, UserDataStore.Users[0].Email);
        }

        [Fact]
        public void RegisterUser_ExistingEmail_ReturnsFailure()
        {
      
            string email = "existinguser@example.com";
            string password = "ValidPassword123!";
            string confirmPassword = password;

            // Register first user
            new RegistrationService().RegisterUser("User1", email, password, confirmPassword);

            // Act
            var result = new RegistrationService().RegisterUser("User2", email, password, confirmPassword);

            // Output result
            _output.WriteLine($"RegisterUser_ExistingEmail_ReturnsFailure: {result.Message}");

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Email already exists!", result.Message);
            Assert.Single(UserDataStore.Users); // No new user should be added
        }

        [Fact]
        public void RegisterUser_InvalidPassword_ReturnsFailure()
        {
    
            string email = "validuser@example.com";
            string password = "short"; // Invalid password (too short)
            string confirmPassword = password;

            
            var result = new RegistrationService().RegisterUser("John Doe", email, password, confirmPassword);

            // Output result
            _output.WriteLine($"RegisterUser_InvalidPassword_ReturnsFailure: {result.Message}");

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Password must be at least 8 characters long, contain a mix of uppercase and lowercase letters, a number, and a special character.", result.Message);
            Assert.Empty(UserDataStore.Users); // User should not be registered
        }

        [Fact]
        public void RegisterUser_PasswordMismatch_ReturnsFailure()
        {
           
            string email = "validuser@example.com";
            string password = "ValidPassword123!";
            string confirmPassword = "DifferentPassword123!";

    
            var result = new RegistrationService().RegisterUser("John Doe", email, password, confirmPassword);

            // Output result
            _output.WriteLine($"RegisterUser_PasswordMismatch_ReturnsFailure: {result.Message}");

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Passwords do not match!", result.Message);
            Assert.Empty(UserDataStore.Users); // User should not be registered
        }

        [Fact]
        public void RegisterUser_InvalidEmail_ReturnsFailure()
        {
      
            string email = "invalid-email"; // Invalid email format
            string password = "ValidPassword123!";
            string confirmPassword = password;


            var result = new RegistrationService().RegisterUser("John Doe", email, password, confirmPassword);

            // Output result
            _output.WriteLine($"RegisterUser_InvalidEmail_ReturnsFailure: {result.Message}");

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Invalid email format.", result.Message);
            Assert.Empty(UserDataStore.Users); // User should not be registered
        }

        #endregion

        #region IsUserValid Tests

        [Fact]
        public void IsUserValid_ValidCredentials_ReturnsTrue()
        {

            string email = "user@example.com";
            string password = "ValidPassword123!";
            new RegistrationService().RegisterUser("ziyad", email, password, password);

            bool result = UserDataStore.IsUserValid(email, password);

            // Output result
            _output.WriteLine($"IsUserValid_ValidCredentials_ReturnsTrue: {result}");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsUserValid_InvalidCredentials_ReturnsFalse()
        {

            string email = "user@example.com";
            string password = "ValidPassword123!";
            new RegistrationService().RegisterUser("ziyad", email, password, password);

            bool result = UserDataStore.IsUserValid(email, "WrongPassword");

            // Output result
            _output.WriteLine($"IsUserValid_InvalidCredentials_ReturnsFalse: {result}");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsUserValid_NonExistentUser_ReturnsFalse()
        {
            bool result = UserDataStore.IsUserValid("nonexistentuser@example.com", "Password123!");

            // Output result
            _output.WriteLine($"IsUserValid_NonExistentUser_ReturnsFalse: {result}");

            // Assert
            Assert.False(result);
        }

        #endregion

        // to clear the Users list after each test
        public void Dispose()
        {
            UserDataStore.Users.Clear();
        }
    }
}
