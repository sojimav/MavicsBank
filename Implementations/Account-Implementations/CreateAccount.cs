using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MavicsBank.Models.Customer_Model;
using MavicsBank.Models.Account_Model;
using MavicsBank.Interfaces.Account_Interface;
using MavicsBank.Interfaces.Customer_Interface;

namespace MavicsBank.Implementations.Account_Implementations
{
    internal class CreateAccount : Acc_Helper, ICreateAccount
    {
        public void CreateNewAccount(Customer loggedInCustomer)
        {
            Console.Write("\n\nLoading\n\n");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(700);
                Console.Write("-");
            }

            Console.Clear();
            Console.WriteLine("\n\u001b[32m:::::::::: CREATE YOUR ACCOUNT:::::::::\u001b[0m\n\n"); // Green color

            var id = loggedInCustomer.Id;
            var fullname  = loggedInCustomer.FullName;
            var accNo = AccountNo();
            var accType = SelectAccountType();
            var bal = Bal(accType);
            if(accType == "savings" || accType == "current")
            {
                Account account = new Account(id, fullname, accNo, accType, bal);

                using (StreamWriter writer = new StreamWriter("Accounts.txt", true))
                {
                  writer.WriteLine($"|  {account.Id,-12} | {account.Name,-16} | {account.AccountNo,-18} | {account.AccountType,-18} | {account.AccountBal,-10} |\n\n");
                }
                Console.WriteLine($" Account for {fullname} with Account no: {accNo} has been added to File.");
            }

            Console.Write("Loading");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(3000);
                Console.Write("-");
            }
          

        }

    }
        
}
