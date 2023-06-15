using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MavicsBank.Models.Customer_Model;
using MavicsBank.Interfaces.Customer_Interface;
using MavicsBank.Interfaces.Account_Interface;

namespace MavicsBank.Implementations.Customer_Implementations
{
    internal class Logout : ILogout
    {
        public void LogoutCustomer(Customer loggedInCustomer)
        {
            loggedInCustomer = null;

            Console.WriteLine("Logged Out!");
            
        }
    }
}
