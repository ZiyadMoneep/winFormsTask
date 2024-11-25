using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WinFormsAppobTask.Services;

namespace WinFormsAppobTask.Services
{
    public class RegistrationService
        {
            public (bool Success, string Message) RegisterUser(string name, string email, string password, string confirmPassword)
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) ||
                    string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
                {
                    return (false, "All fields are required!");
                }

                // Validate email format
                if (!ValidationService.IsValidEmail(email))
                {
                    return (false, "Invalid email format.");
                }

                // Validate password strength
                if (!ValidationService.IsValidPassword(password))
                {
                    return (false, "Password must be at least 8 characters long, contain a mix of uppercase and lowercase letters, a number, and a special character.");
                }

                // Check if passwords match
                if (password != confirmPassword)
                {
                    return (false, "Passwords do not match!");
                }

                // Attempt to register the user
                if (!UserDataStore.RegisterUser(email, password))
                {
                    return (false, "Email already exists!");
                }

                // Success
                return (true, "Registration Successful!");
            }
        }
    }
