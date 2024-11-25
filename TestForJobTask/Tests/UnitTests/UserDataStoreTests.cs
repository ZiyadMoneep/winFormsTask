using System;
using Xunit;
using Xunit.Abstractions;
using WinFormsAppobTask.Services;

namespace WinFormsAppobTask.Tests.UnitTests
{
    public class UserDataStoreTests : IDisposable
    {
        private readonly ITestOutputHelper _output;

        // inject ITestOutputHelper
        public UserDataStoreTests(ITestOutputHelper output)
        {
            _output = output;
            // Reset the Users list for testing.
            UserDataStore.Users.Clear();
        }

        [Fact]
        public void IsUserValid_ValidUser_ReturnsTrue()
        {
            
            var email = "test@example.com";
            var password = "Test123!";

            // Add user
            UserDataStore.RegisterUser(email, password);

           
            bool result = UserDataStore.IsUserValid(email, password);

            // Output result
            _output.WriteLine($"Test IsUserValid_ValidUser_ReturnsTrue: {result}");

           
            Assert.True(result);
        }

        [Fact]
        public void IsUserValid_InvalidUser_ReturnsFalse()
        {
           
            var email = "wrong@example.com";
            var password = "Wrong123!";

           
            bool result = UserDataStore.IsUserValid(email, password);

            // Output result
            _output.WriteLine($"Test IsUserValid_InvalidUser_ReturnsFalse: {result}");

          
            Assert.False(result);
        }

        //[Fact]
        //public void UpdateEmail_ValidEmail_ReturnsTrue()
        //{
        //    var email = "test@example.com";
        //    var newEmail = "newemail@example.com";

        //    // Register the user
        //    UserDataStore.RegisterUser(email, "Test123!");

        //    // Print out CurrentUser to see if it's initialized correctly
        //    _output.WriteLine($"CurrentUser after registration: {UserDataStore.CurrentUser?.Email}");

        //    // Ensure CurrentUser is set correctly after registration
        //    Assert.NotNull(UserDataStore.CurrentUser);
        //    Assert.Equal(email, UserDataStore.CurrentUser.Email);

        //    // Now attempt to update the email
        //    bool result = UserDataStore.UpdateEmail(newEmail);

        //    // Output result
        //    _output.WriteLine($"Test UpdateEmail_ValidEmail_ReturnsTrue: {result}");

        //    // Assert the email update was successful
        //    Assert.True(result);
        //    Assert.Equal(newEmail, UserDataStore.CurrentUser.Email);
        //}


        [Fact]
        public void UpdateEmail_EmailAlreadyExists_ReturnsFalse()
        {
           
            var email = "test@example.com";
            var existingEmail = "existing@example.com";
            UserDataStore.RegisterUser(email, "Test123!");
            UserDataStore.RegisterUser(existingEmail, "Test456!");

        
            bool result = UserDataStore.UpdateEmail(existingEmail);

            // Output result
            _output.WriteLine($"Test UpdateEmail_EmailAlreadyExists_ReturnsFalse: {result}");

          
            Assert.False(result);
        }

        // to clear the Users list after each test
        public void Dispose()
        {
            UserDataStore.Users.Clear();
        }
    }
}
