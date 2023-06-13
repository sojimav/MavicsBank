using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MavicsBank.Models.Account_Model
{
    internal class Account
    {
        public Account(int id, string name, int accountNo, string accountType, decimal accountBal)
        {
            Id = id;
            Name = name;
            AccountNo = accountNo;
            AccountType = accountType;
            AccountBal = accountBal;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AccountNo { get; set; }
        public string AccountType { get; set; }
        public decimal AccountBal { get; set; } 

    }
}
