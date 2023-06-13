using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MavicsBank.Models.Account_Model;
using MavicsBank.Models.Customer_Model;

namespace MavicsBank.Implementations.Account_Implementations
{
    internal class StatementOfAccount
    {
        public void MyStatementOfAccount(Customer loggedInCustomer)
        {
            string display = "";
            using(StreamReader reader = new StreamReader("Transaction.txt"))
            {

                string read;
                while ((read = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(read))
                    {
                        string[] lines = read.Split("|");

                        if (lines.Length >= 6 )
                        {
                            display += $"|  {lines[3],-14}  |  {lines[4],-14}  |   {lines[5],-15}  |  {lines[6],-15}  |\n";
                        }
                    }
                }
            }

            Console.WriteLine($"::::::::::::::: STATEMENT OF ACCOUNT FOR {loggedInCustomer.FullName}::::::::::::::::::::");
            Console.WriteLine();
            Console.WriteLine("|-------------------|-------------------|--------------------|-------------------|");
            Console.WriteLine("|        DATE       |    DESCRIPTION    |       AMOUNT       |      BALANCE      |");
            Console.WriteLine("|-------------------|-------------------|--------------------|-------------------|");
            Console.WriteLine(display);
            Console.WriteLine("|--------------------------------------------------------------------------------|");


        }

    }
}
