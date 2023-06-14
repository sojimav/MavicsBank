using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MavicsBank.Models.Account_Model;
using MavicsBank.Models.Customer_Model;
using MavicsBank.Interfaces.Account_Interface;

namespace MavicsBank.Implementations.Account_Implementations
{
    internal class Transfer : ITransfer
    {
        private readonly IAccHelper _accHelper;
        public Transfer(IAccHelper accHelper)
        {
            _accHelper = accHelper;
        }
        public void TransferMoney(Customer loggedInCustomer)
        {
            List<Account> accounts = Acc_Helper.ReadFromAccountFile("Accounts.txt");

           var accountFrom =  _accHelper.EnterAccountNoTo("transfer from");       
           var accountTo = _accHelper.EnterAccountNoTo("tranfer to");
           var amountToTransfer =  _accHelper.EnterAmountTo("transfer");
           
           var AllAccountsOfLoggedInPerson = accounts.Where(accRows => accRows.Id == loggedInCustomer.Id).ToList();
            var giver = AllAccountsOfLoggedInPerson.FirstOrDefault(x => x.AccountNo == accountFrom);
            var receiver = accounts.FirstOrDefault(row => row.AccountNo == accountTo);
           
            if (giver != null && receiver != null)
            {
                if ((amountToTransfer <= giver.AccountBal && giver.AccountType.Trim() == "current")
                  || (giver.AccountType.Trim() == "savings" && giver.AccountBal - amountToTransfer > 1000))
                {
                    giver.AccountBal -= amountToTransfer;
                    receiver.AccountBal += amountToTransfer;
                    Console.WriteLine($"{amountToTransfer} has been successfully transfered to {receiver.Name}");
                    _accHelper.CreateAndWriteToAccountFile("Accounts.txt", accounts, loggedInCustomer);
                 
                    var givertransactionRecords = new Transactions
                    {
                        Id = loggedInCustomer.Id, Name = giver.Name, TimeOfTransaction = DateTime.Now, Description = $"transfered to {receiver.Name}",
                        Amount = amountToTransfer, Balance = giver.AccountBal, AccountNo = giver.AccountNo
                    };
                     _accHelper.CreateTransactionFile(givertransactionRecords);

                    var receivertransactionRecords = new Transactions
                    {
                        Id = receiver.Id, Name = receiver.Name, TimeOfTransaction = DateTime.Now, Description = $" received from {giver.Name}",
                        Amount = amountToTransfer,  Balance = receiver.AccountBal, AccountNo = receiver.AccountNo
                    };
                    _accHelper.CreateTransactionFile(receivertransactionRecords);
                  
                }
                else
                {
                   Console.WriteLine($"\u001b[31mInsufficient Amount, you only have {giver.AccountBal} in your account\u001b[0m");   // Red color
                }
            }
            else
            {
                Console.WriteLine("\u001b[31m Error in Transaction! Wrong account Number! \u001b[0m");   // Red color
            }


        }
    }
}
