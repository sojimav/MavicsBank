using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MavicsBank.Interfaces.Account_Interface;
using MavicsBank.Models.Account_Model;
using MavicsBank.Models.Customer_Model;

namespace MavicsBank.Implementations.Account_Implementations
{
    internal class CheckBalance : ICheckBalance
    {
        public void CheckMyBalance(Customer loggedInCustomer)
        {
            List<Account> accounts = Acc_Helper.ReadFromAccountFile("Accounts.txt");


            Console.Write("Enter account number to CHECK BALANCE: ");
            var accountNo = decimal.Parse(Console.ReadLine());

            var AllAccountsOfLoggedInPerson = accounts.Where(accRows => accRows.Id == loggedInCustomer.Id).ToList();
            var FetchRowToCheck = AllAccountsOfLoggedInPerson.FirstOrDefault(x => x.AccountNo == accountNo);

          
            Console.WriteLine("::::::::::::::::::: ACCOUNT BALANCE :::::::::::::::::::::::::::::::::");
            Console.WriteLine();
            if(FetchRowToCheck != null)
            {
              Console.WriteLine($"Your account balance is: {FetchRowToCheck.AccountBal}");
            }
            else
            {
                Console.WriteLine("Account number does not exist!");
            }
            
           
        }
    }
}
