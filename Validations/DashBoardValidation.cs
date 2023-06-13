﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MavicsBank.Validations
{
    internal class DashBoardValidation
    {
        public static bool DashBoardValid(string value)
        {
            bool isValid = false;
            switch (value)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "Q":
                    isValid = true;
                    break;
            }

            return isValid;
        }
    }
}
