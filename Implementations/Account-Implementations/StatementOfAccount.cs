using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MavicsBank.Models.Account_Model;
using MavicsBank.Models.Customer_Model;
using MavicsBank.Interfaces.Account_Interface;
using System.Data;

namespace MavicsBank.Implementations.Account_Implementations
{
    internal class StatementOfAccount : IStatementOfAccount
    {
        public void MyStatementOfAccount(Customer loggedInCustomer)
        {
            string display = "";
            var allTransactions = ReadTransactionFile();

            var accountNo = AccountNo();
            var getallRows = allTransactions.Where(rows => rows.Id == loggedInCustomer.Id && rows.AccountNo == accountNo ).ToList();

            if(getallRows.Any())
            {
                foreach (var acc in getallRows)
                {
                    display += $"|  {acc.TimeOfTransaction,-14}  |   {acc.Description,-14}  |  {acc.Amount,-15}  |  {acc.Balance,-15}  |\n";
                }

                Console.WriteLine($"::::::::::::::: STATEMENT OF ACCOUNT FOR ACCOUNT NO: {accountNo}::::::::::::::::::::");
                Console.WriteLine();
                Console.WriteLine("|-----------------------|-------------------|-------------------|-------------------|");
                Console.WriteLine("|        DATE           |    DESCRIPTION    |       AMOUNT      |      BALANCE      |");
                Console.WriteLine("|-----------------------|-------------------|-------------------|-------------------|");
                Console.WriteLine(display);
                Console.WriteLine("|-----------------------------------------------------------------------------------|");
            }
            else
            {
                Console.WriteLine("Account Number does not exist!");
            }
            

        }

        public int AccountNo()
        {
            Console.WriteLine("Enter account no: ");
            string accountNo = Console.ReadLine();
            int validAccount = int.Parse(accountNo);

            return validAccount;
        }

        public List<Transactions> ReadTransactionFile()
        {
            List<Transactions> list = new List<Transactions>();
            using (StreamReader reader = new StreamReader("Transaction.txt"))
            {
               
                string read;
                while ((read = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(read))
                    {
                        string[] lines = read.Split("|");

                        if (lines.Length >= 6)
                        {
                            
                           var transaction = new Transactions
                            {
                                Id = int.Parse(lines[1].Trim()),
                                Name = lines[2].Trim(),
                                TimeOfTransaction = DateTime.Parse(lines[3].Trim()),
                                Description = lines[4].Trim(),
                                Amount = decimal.Parse(lines[5].Trim()),
                                Balance = decimal.Parse(lines[6].Trim()),
                                AccountNo = int.Parse(lines[7].Trim())
                            };

                            list.Add(transaction);
                        }
                    }
                }

                return list;
            }
        }
    }
}
