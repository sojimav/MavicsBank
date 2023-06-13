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
            //var receiver = AllAccountsOfLoggedInPerson.FirstOrDefault(x => x.AccountNo == accountTo);

            if (giver != null && receiver != null)
            {
                if ((amountToTransfer <= giver.AccountBal && giver.AccountType.Trim() == "current")
                    || (giver.AccountType.Trim() == "savings" && giver.AccountBal - amountToTransfer > 1000))
                {
                    giver.AccountBal -= amountToTransfer;
                    receiver.AccountBal += amountToTransfer;

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
