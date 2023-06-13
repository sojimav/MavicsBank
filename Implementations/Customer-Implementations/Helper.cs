using MavicsBank.Models.Customer_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MavicsBank.Implementations.Customer_Implementations
{
    internal class Helper
    {
       public static void LoginInstruction()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter Login details (Email and Password!)\n");
            Console.ResetColor();
        }
        public static void RegInstruction()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n Registration Portal\n");
            Console.ResetColor();
        }

        public string FullName()
        {
            string fullName = "";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nName must start with a Capital Letter!\n");
            Console.ResetColor();
            Console.Write("Enter Full Name:\n");
            fullName = Console.ReadLine()!;
       
            return fullName;
        }

        public string Email()
        {
            string email = "";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nEnter a Valid Email Format!\n");
            Console.ResetColor();
            email = Console.ReadLine()!;
            return email;
        }

        public string Password()
        {
            string password = "";       
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPassword must be 6 character with at least 1 special charater and 1 digt!\n");
            Console.ResetColor();
            Console.Write("Create Your Password:\n");
            password = Console.ReadLine()!;
        
            return password;

        }

        public int CustomerId()
        {
            Random account = new Random();
           int id = account.Next(10000000, 20000000);

            return id;
        }

        public static List<Customer> ReadFromFile(string filepath)
        {
            var detailsFromFile = new List<Customer>();
            using (StreamReader reader = new StreamReader(filepath))
            {
                string? read;
                while ((read = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(read))
                    {
                        string[] lines = read.Split("|");

                        if (lines.Length >= 4)
                        {
                            int id = int.Parse(lines[1].Trim());
                            string fullName = lines[2].Trim();
                            string email = lines[3].Trim();
                            string password = lines[4].Trim();
                            Customer customer = new Customer(id, fullName, email, password);
                            detailsFromFile.Add(customer);
                        }
                    }
                }
            }

            return detailsFromFile;
        }


    }
}
