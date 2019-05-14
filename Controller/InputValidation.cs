using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Controller
{
    /// <summary>
    /// Refers to how strict the password input should be
    /// </summary> 
    public enum Strictness { NotStrict, Strict, VeryStrict };
    public static class InputValidation
    {
         

        public static void ValidatePassword(String password)
        {
            /// This is how strct the password is. 
            int StrictnessLevel = (int)Strictness.Strict;

            if (StrictnessLevel == (int)Strictness.NotStrict) return;

            if (password.Length < 8)
                throw new Exceptions.ValidationException("Password must be at least 8 characters long");

            if (password.Length > 50)
                throw new Exceptions.ValidationException("Password must be less than 50 characters long");

            if (password.ToLower() == password.ToUpper())
                throw new Exceptions.ValidationException("Password must have uppercase and lowercase characters");

            if (StrictnessLevel == (int)Strictness.Strict) return;

            /// Regular expressions to test password against
            Regex ContainsNumber = new Regex(@"[0-9]+");
            Regex ContainsSymbol = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!ContainsNumber.IsMatch(password))
                throw new Exceptions.ValidationException("Password must contain at least 1 number");

            if (!ContainsSymbol.IsMatch(password))
                throw new Exceptions.ValidationException("Password must contain at least 1 symbol");
            
        }
        public static void ValidateUsername(String username)
        {
            if (username.Length < 3)
                throw new Exceptions.ValidationException("Username must be at least 3 characters long");

            if (username.Length > 15)
                throw new Exceptions.ValidationException("Username must be less than 15 characters long");
            
        }
    }
}
