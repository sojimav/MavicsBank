using MavicsBank.Models.Account_Model;
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
    }
}
