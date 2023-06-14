using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MavicsBank.Models.Account_Model
{
    internal class Transactions
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeOfTransaction { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; } 
        public decimal Balance { get; set; }    
        public int AccountNo { get; set; }   

    }
}
