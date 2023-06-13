using MavicsBank.Models.Customer_Model;
using MavicsBank.Models.Account_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Security.AccessControl;
using MavicsBank.Interfaces.Account_Interface;



namespace MavicsBank.Implementations.Account_Implementations
{
    internal class Deposit : IDeposit
    {
        private readonly IAccHelper _accHelper;
        public Deposit(IAccHelper accHelper)
        {
            _accHelper = accHelper;
        }

        public void DepositMoney(Customer loggedInCustomer)
        {  
            
            List<Account> accounts = Acc_Helper.ReadFromAccountFile("Accounts.txt");


            Console.WriteLine("Enter Amount to Deposit: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            int getAccoutNo;
            Console.Write("Enter the Account Number to Deposit to: ");
            getAccoutNo = int.Parse(Console.ReadLine());
            Console.WriteLine();
             
          var AllAccountsOfLoggedInPerson = accounts.Where(accRows => accRows.Id == loggedInCustomer.Id).ToList();

            var FetchRowToUpdate = AllAccountsOfLoggedInPerson.FirstOrDefault(x => x.AccountNo == getAccoutNo);
            Transactions recordTransactions;
            if (FetchRowToUpdate != null)
            {               
                FetchRowToUpdate.AccountBal += amount ;
                Console.WriteLine($"{amount} has been successfully deposited into your account : {getAccoutNo}");
                 recordTransactions = new Transactions
                { 
                    Id = loggedInCustomer.Id,
                    Name = loggedInCustomer.FullName,
                    TimeOfTransaction = DateTime.Now,
                    Description = "deposit",
                    Amount = amount,
                    Balance = FetchRowToUpdate.AccountBal

                };
                _accHelper.CreateTransactionFile(recordTransactions);

            }
            else
            {
                Console.WriteLine("Account Number does not exist!");
            }

           using (StreamWriter writer = new StreamWriter("Accounts.txt", false))
            {
                foreach(var account in accounts)
                {
                   writer.WriteLine($"|  {account.Id,-12} | {account.Name,-16} | {account.AccountNo,-18} | {account.AccountType,-18} | {account.AccountBal,-10} |\n\n");
                    //Console.WriteLine($"Transaction has been update for {loggedInCustomer.FullName} with account No: {FetchRowToUpdate.AccountNo} in file");
                    
                }
                
            }

           

        }

    }
}
