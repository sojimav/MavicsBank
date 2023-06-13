using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MavicsBank.Models.Customer_Model;
using MavicsBank.Models.Account_Model;
using MavicsBank.Interfaces.Account_Interface;

namespace MavicsBank.Implementations.Account_Implementations
{
    internal class CreateAccount : Acc_Helper, ICreateAccount
    {
        public void CreateNewAccount(Customer loggedInCustomer)
        {
            var id = loggedInCustomer.Id;
            var fullname  = loggedInCustomer.FullName;
            var accNo = AccountNo();
            var accType = SelectAccountType();
            var bal = Bal(accType);

            Account account = new Account(id,fullname,accNo,accType,bal);

            using (StreamWriter writer = new StreamWriter("Accounts.txt", true))
            {
                writer.WriteLine($"|  {account.Id,-12} | {account.Name,-16} | {account.AccountNo,-18} | {account.AccountType,-18} | {account.AccountBal,-10} |\n\n");
            }
            Console.WriteLine($" Account for {fullname} with Account no: {accNo} has been added to File.");
        }







    }
      
    
}
