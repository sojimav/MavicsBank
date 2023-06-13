﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MavicsBank.Interfaces.Customer_Interface;

namespace MavicsBank.Implementations.Customer_Implementations
{
    internal class Login : Helper, ILogin
    {
        private readonly IDashBoard _board;
        public Login(IDashBoard dash)
        {
            _board = dash;
        }

        public void LogMeIn()
        {
            var allCustomers = ReadFromFile("Customers.txt");
            LoginInstruction();
           var email =  Email();
           var password =  Password();

            var logginInCustormer = allCustomers.FirstOrDefault(x => x.Email == email && x.Password == password);
            if(logginInCustormer != null)
            {
                Console.WriteLine("Congratulations! You have been logged in!");
                _board.MyDashBoard(logginInCustormer);
            }
            else
            {
                Console.WriteLine("Invalid Login Details!");
            }
            
            
        }
    }
}
