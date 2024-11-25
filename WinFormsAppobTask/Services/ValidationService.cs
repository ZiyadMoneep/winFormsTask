using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppobTask.Services
{
    public static class ValidationService
    {
        public static bool IsValidPassword(string password)
        {
            // Password rules:
            var passwordPattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(password, passwordPattern);
        }

        public static bool IsValidEmail(string email)
        {
            // Basic email validation
            var emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern);
        }
    }
}
