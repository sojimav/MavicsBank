using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MavicsBank.Validations
{
    public class HelperValidation
    {
        public static bool FullNameValidation(string fullname)
        {
            bool isValid = false;
            Regex checkName = new Regex("^[A-Z][a-z]{2,29}( [A-Z][a-z]{2,29})+$");
            if (checkName.IsMatch(fullname))
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool EmailValidation(string email)
        {
            bool isValid = false;
            Regex checkEmail = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
            if (checkEmail.IsMatch(email))
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool PasswordValidation(string password)
        {
            bool isValid = false;
            Regex passwordValidation = new Regex("^(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$");
            if (passwordValidation.IsMatch(password))
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
