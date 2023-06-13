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

            Console.Write("Enter account to transfer from: ");
            var accountFrom = int.Parse(Console.ReadLine());

            Console.Write("Enter account to transfer to: ");
            var accountTo = int.Parse(Console.ReadLine());

            Console.Write("Enter amount to transfer: ");
            var amountToTransfer = decimal.Parse(Console.ReadLine());

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

                    var givertransactionRecords = new Transactions
                    {
                        Id = loggedInCustomer.Id,
                        Name = giver.Name,
                        TimeOfTransaction = DateTime.Now,
                        Description = $"transfered to {receiver.Name}",
                        Amount = amountToTransfer,
                        Balance = giver.AccountBal
                    };
                     _accHelper.CreateTransactionFile(givertransactionRecords);
                    var receivertransactionRecords = new Transactions
                    {
                        Id = receiver.Id,
                        Name = receiver.Name,
                        TimeOfTransaction = DateTime.Now,
                        Description = $" received from {giver.Name}",
                        Amount = amountToTransfer,
                        Balance = receiver.AccountBal
                    };
                    _accHelper.CreateTransactionFile(receivertransactionRecords);
                    Console.WriteLine($"{amountToTransfer} has been successfully transfered to {receiver.Name}");
                }
                else
                {
                    Console.WriteLine($"Insufficient Amount, you only have {giver.AccountBal} in your account");
                }
            }
            else
            {
                Console.WriteLine("Error in Transaction! Wrong account Number!");
            }

            using (StreamWriter writer = new StreamWriter("Accounts.txt", false))
            {
                foreach (var account in accounts)
                {
                    writer.WriteLine($"|  {account.Id,-12} | {account.Name,-16} | {account.AccountNo,-18} | {account.AccountType,-18} | {account.AccountBal,-10} |\n\n");

                }
                if (receiver != null)
                    Console.WriteLine($"Transaction has been update for {loggedInCustomer.FullName} and {receiver.Name} in file");
            }

        }
    }
}
