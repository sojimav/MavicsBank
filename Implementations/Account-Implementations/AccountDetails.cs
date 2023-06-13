using MavicsBank.Models.Account_Model;
using MavicsBank.Models.Customer_Model;
using MavicsBank.Interfaces.Account_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MavicsBank.Implementations.Account_Implementations
{
    internal class AccountDetails : IAccountDetails
    {
        public void DisplayAccountDetails(Customer logginedInCustomer)
        {
            List<Account> accounts = Acc_Helper.ReadFromAccountFile("Accounts.txt");

            List<Account> getAllAccOfLogCustomer = accounts.Where(account => account.Id == logginedInCustomer.Id).ToList();

            string allrows = "";
            foreach (Account acc in getAllAccOfLogCustomer)
            {
                Console.WriteLine("|-----------------------------------------------------------------------------------------------------------------|");
                      allrows += $"|   {acc.Id,-14}  |   {acc.Name,-14}  |   {acc.AccountNo,-15}  |  {acc.AccountType,-15}  |  {acc.AccountBal,-16}  |\n";
                Console.WriteLine("|-----------------------------------------------------------------------------------------------------------------|");
            }

           Console.WriteLine($":::::::::::::::::::::: ACCOUNT DETAILS FOR {logginedInCustomer.FullName}::::::::::::::::::::::::::::::");

            Console.WriteLine("|-------------------|-------------------|--------------------|-------------------|--------------------|");
            Console.WriteLine("|     CUSTOMER_ID   |    FULLNAME       |     ACCOUNT_NO     |   ACCOUNT_TYPE    |   ACCOUNT BALANCE  |");
            Console.WriteLine("|-------------------|-------------------|--------------------|-------------------|--------------------|");
            Console.WriteLine(allrows);
            Console.WriteLine("|-----------------------------------------------------------------------------------------------------|");

        }

    }
}
