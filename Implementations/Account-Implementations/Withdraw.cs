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
        private readonly IAccHelper _accHelper;
        public Withdraw(IAccHelper helper)
        {
            _accHelper = helper;
        }
        public void WithdrawMoney(Customer loggedInCustomer)
        {
            List<Account> accounts = Acc_Helper.ReadFromAccountFile("Accounts.txt");

            decimal amount = _accHelper.EnterAmountTo("withdraw");
            int getAccountNo = _accHelper.EnterAccountNoTo("withdraw from");
        
            var AllAccountsOfLoggedInPerson = accounts.Where(accRows => accRows.Id == loggedInCustomer.Id).ToList();
            var FetchRowToUpdate = AllAccountsOfLoggedInPerson.FirstOrDefault(x => x.AccountNo == getAccountNo);

            if (FetchRowToUpdate != null)
            {                
                if((amount <= FetchRowToUpdate.AccountBal && FetchRowToUpdate.AccountType.Trim() == "current") 
                    || (FetchRowToUpdate.AccountType.Trim() == "savings" && FetchRowToUpdate.AccountBal - amount > 1000))     
                {
                    FetchRowToUpdate.AccountBal -= amount;
                    Console.WriteLine($"{amount} has been successfully withdrawn from your account : {getAccountNo}");
                    _accHelper.CreateAndWriteToAccountFile("Accounts.txt", accounts, loggedInCustomer);

                    var transaction = new Transactions
                    {
                        Id = loggedInCustomer.Id,
                        Name = loggedInCustomer.FullName,
                        TimeOfTransaction = DateTime.Now,
                        Description = "withdrawal",
                        Amount = amount,
                        Balance = FetchRowToUpdate.AccountBal,
                        AccountNo = FetchRowToUpdate.AccountNo                     
                    };

                    _accHelper.CreateTransactionFile(transaction); 
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
         

        }
    }
}
