using MavicsBank.Models.Customer_Model;
using MavicsBank.Models.Account_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MavicsBank.Interfaces.Account_Interface;
using MavicsBank.Interfaces.Customer_Interface;

namespace MavicsBank.Implementations.Account_Implementations
{
    internal class Acc_Helper : IAccHelper
    {
        private readonly IDashBoard _board;
       
        public int AccountNo()
        {
            Random account = new Random();
            int id = account.Next(1000000000, 2000000000);

            return id;
        }

        public string SelectAccountType()
        {
            string accType = "";
            string readInput;
            
                Console.WriteLine("\u001b[34mSelect Account Type\u001b[0m\n");  // Blue color
                Console.Write(">> 1 for Savings Account\n>> 2 for Current Account\n>> Any Value for DashBoard\n\nEnter Choice: ");
                readInput = Console.ReadLine()!;
                if (readInput == "1")
                {
                    accType = "savings";
                }
                else if (readInput == "2")
                {
                    accType = "current";
                }
               
            return accType;
        }


        public decimal Bal(string accTy)
        {
            decimal Balance = 0;
            if (accTy == "current")
            {
                Balance = 0;
            }
            else if (accTy == "savings")
            {
                Console.Write($"Please enter an amount not less than 1000>>");
                var bal = Console.ReadLine();
                Balance = Convert.ToDecimal(bal);
            }

            return Balance;
        }


        public static List<Account> ReadFromAccountFile(string filepath)
        {
            var AccountdetailsFromFile = new List<Account>();
            using (StreamReader reader = new StreamReader(filepath))
            {
                string? read;
                while ((read = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(read))
                    {
                        string[] lines = read.Split("|");

                        if (lines.Length >= 5)
                        {
                            int id = int.Parse(lines[1].Trim());
                            string fullName = lines[2].Trim();
                            int accountNo = int.Parse(lines[3].Trim());
                            string accountType = lines[4].Trim();
                            decimal accountBal = decimal.Parse(lines[5].Trim());
                            Account account = new Account(id, fullName, accountNo, accountType, accountBal);
                            AccountdetailsFromFile.Add(account);
                        }
                    }
                }
            }

            return AccountdetailsFromFile;
        }


        public void CreateTransactionFile(Transactions transactions)
        {
            using (StreamWriter trans = new StreamWriter("Transaction.txt", true))
            {
                trans.WriteLine($"| {transactions.Id} | {transactions.Name} | {transactions.TimeOfTransaction} | {transactions.Description} | {transactions.Amount} | {transactions.Balance} |\n\n");
            }
        }
    }
}