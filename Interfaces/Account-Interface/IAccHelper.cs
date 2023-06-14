using MavicsBank.Models.Account_Model;
using MavicsBank.Models.Customer_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MavicsBank.Interfaces.Account_Interface
{
    internal interface IAccHelper
    {
         void CreateTransactionFile(Transactions transactions);
         decimal EnterAmountTo(string action);
         int EnterAccountNoTo(string action);
         void CreateAndWriteToAccountFile(string filePath, List<Account> accounts, Customer loggedInCustomer);

    }
}
