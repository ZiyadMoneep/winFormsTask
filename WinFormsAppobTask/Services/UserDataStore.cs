using System;
using System.Collections.Generic;
using System.Linq;
using WinFormsAppobTask.Models;

namespace WinFormsAppobTask.Services
{
    public static class UserDataStore
    {
        #region Properties

        public static List<User> Users { get; private set; } = new List<User>();
        public static User CurrentUser { get; private set; } // Tracks the currently logged-in user

        #endregion

        #region User Authentication


        // Validates if the provided email and password match an existing user.
        public static bool IsUserValid(string email, string password)
        {
            CurrentUser = Users.FirstOrDefault(user => user.Email == email && user.Password == password);
            return CurrentUser != null;
        }

        #endregion

        #region User Registration


        // Registers a new user with the specified email and password.
        public static bool RegisterUser(string email, string password)
        {
            if (IsEmailUnique(email))
            {
                Users.Add(new User { Email = email, Password = password });
                Console.WriteLine($"User Registered: {email}"); // Log
                return true;
            }
            return false; // Registration failed
        }

        #endregion

        #region User Updates


        // Updates the current user's email if the new email is unique.
        public static bool UpdateEmail(string newEmail)
        {
            if (CurrentUser != null)
            {
                if (IsEmailUnique(newEmail))
                {
                    CurrentUser.Email = newEmail;
                    return true;
                }
            }
            
            return false; // Update failed
        }

        // Updates the current user's password.
        public static bool UpdatePassword(string newPassword)
        {
            if (CurrentUser != null)
            {
                CurrentUser.Password = newPassword;
                return true;
            }
            return false;
        }

        #endregion

        #region Helper Methods


        // Checks if the given email is unique in the user list.
        private static bool IsEmailUnique(string email)
        {
            return Users.All(user => user.Email != email);
        }

        #endregion
    }

   
}
