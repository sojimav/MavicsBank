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
            Console.Clear();
         
             List<Account> accounts = Acc_Helper.ReadFromAccountFile("Accounts.txt");

             decimal amount =  _accHelper.EnterAmountTo("deposit");
             int getAccountNo = _accHelper.EnterAccountNoTo("deposit to");
            
             var AllAccountsOfLoggedInPerson = accounts.Where(accRows => accRows.Id == loggedInCustomer.Id).ToList();
             var FetchRowToUpdate = AllAccountsOfLoggedInPerson.FirstOrDefault(x => x.AccountNo == getAccountNo);
            if (FetchRowToUpdate != null && amount > 0)
            {               
                FetchRowToUpdate.AccountBal += amount;
                Console.WriteLine($"{amount} has been successfully deposited into your account: {getAccountNo}");
                _accHelper.CreateAndWriteToAccountFile("Accounts.txt", accounts, loggedInCustomer);
                Transactions recordTransactions = new Transactions
                { 
                    Id = loggedInCustomer.Id,
                    Name = loggedInCustomer.FullName,
                    TimeOfTransaction = DateTime.Now,
                    Description = "deposit",
                    Amount = amount,
                    Balance = FetchRowToUpdate.AccountBal,
                    AccountNo = FetchRowToUpdate.AccountNo
                    
                };
                _accHelper.CreateTransactionFile(recordTransactions);    
            }
            else
            {
                Console.WriteLine("\u001b[31mInvalid Entry!.\u001b[0m");  // Red color
            }

           

           

        }

    }
}
