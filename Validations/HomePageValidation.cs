using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MavicsBank.Validations
{
    internal class HomePageValidation
    {
        public static bool InitialPromptValidation(string userInput)
        {
            bool IsValid = false;
            if (!string.IsNullOrWhiteSpace(userInput))
            {
                if (userInput == "1" || userInput.ToUpper() == "Q" || userInput == "2")
                {
                    IsValid = true;
                }
            }

            return IsValid;
        }
    }
}
