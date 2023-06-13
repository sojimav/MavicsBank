using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MavicsBank.Models.Account_Model;
using MavicsBank.Models.Customer_Model;

namespace MavicsBank.Implementations.Account_Implementations
{
    internal class CheckBalance
    {
        public void CheckMyBalance(Customer loggerdInCustomer)
        {
            List<Account> accounts = Acc_Helper.ReadFromAccountFile("Accounts.txt");

        }
    }
}
