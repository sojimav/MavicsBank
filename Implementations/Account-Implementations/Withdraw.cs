using MavicsBank.Models.Account_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MavicsBank.Models.Customer_Model;
using MavicsBank.Interfaces.Account_Interface;
using System.Security.Principal;

namespace MavicsBank.Implementations.Account_Implementations
{
    internal class Withdraw : IWithdraw
    {
        public void WithdrawMoney(Customer loggedInCustomer)
        {
            List<Account> accounts = Acc_Helper.ReadFromAccountFile("Accounts.txt");


            Console.WriteLine("Enter Amount to Withdraw: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            int getAccoutNo;
            Console.Write("Enter the Account Number to Withdraw from: ");
            getAccoutNo = int.Parse(Console.ReadLine());
            Console.WriteLine();

            var AllAccountsOfLoggedInPerson = accounts.Where(accRows => accRows.Id == loggedInCustomer.Id).ToList();

            var FetchRowToUpdate = AllAccountsOfLoggedInPerson.FirstOrDefault(x => x.AccountNo == getAccoutNo);

            if (FetchRowToUpdate != null)
            {                
                if((amount <= FetchRowToUpdate.AccountBal && FetchRowToUpdate.AccountType.Trim() == "current") 
                    || (FetchRowToUpdate.AccountType.Trim() == "savings" && FetchRowToUpdate.AccountBal - amount > 1000))     
                {
                    FetchRowToUpdate.AccountBal -= amount;
                    Console.WriteLine($"{amount} has been successfully withdrawn from your account : {getAccoutNo}");
                    //Console.WriteLine($"Transaction has been update for {loggedInCustomer.FullName} in file");
                }
                
                else
                {
                    Console.WriteLine($"Insufficient Amount, you only have {FetchRowToUpdate.AccountBal} in your account");
                }
               
            }
            else
            {
                Console.WriteLine("Account Number does not exist!");
            }

            using (StreamWriter writer = new StreamWriter("Accounts.txt", false))
            {
                foreach (var account in accounts)
                {
                    writer.WriteLine($"|  {account.Id,-12} | {account.Name,-16} | {account.AccountNo,-18} | {account.AccountType,-18} | {account.AccountBal,-10} |\n\n");
                    
                }
                Console.WriteLine($"Transaction has been update for {loggedInCustomer.FullName} in file");
            }

        }
    }
}
