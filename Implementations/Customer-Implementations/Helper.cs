using MavicsBank.Models.Customer_Model;
using MavicsBank.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MavicsBank.Implementations.Customer_Implementations
{
    internal class Helper : HelperValidation
    {
       public static void LoginInstruction()
        {
            
            //Console.WriteLine("Enter Login details (Email and Password!)\n");
            Console.WriteLine("\u001b[34m Enter Login details (Email and Password!\u001b[0m");  // Blue color
        }
        public static void RegInstruction()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\u001b[32m::::::::::::::::::::Registration Portal:::::::::::::::::::::\u001b[0m");
            Console.WriteLine("\n");
        }

        public static void WelcomeToLogin()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\u001b[32m::::::::::::::::::::Login Portal:::::::::::::::::::::\u001b[0m");
            Console.WriteLine("\n");
        }

        public static void CongratulateRegistrer(string name)
        {
            Console.WriteLine($"\u001b[32m Congrats! {name}, Registration Successful!\u001b[0m");
        }

        public string FullName()
        {
            string fullName = "";
            do
            {
               
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nName must start with a Capital Letter!\n");
                Console.ResetColor();
                Console.Write("Enter Full Name:\n");
                fullName = Console.ReadLine()!;

                if (!FullNameValidation(fullName))
                {
                   Console.WriteLine("\u001b[31mEnter a Valid Name Format! e.g Ajibade Victor \u001b[0m"); 
                }
            }
            while (!FullNameValidation(fullName));
           
       
            return fullName;
        }

        public string Email()
        {
            string email = "";
            do
            { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nEnter an Email e.g mashayete@gmail.com\n");
                Console.ResetColor();
                email = Console.ReadLine()!;

                if (!EmailValidation(email))
                {
                    Console.WriteLine("\u001b[31m Invalid Email Format! \u001b[0m");
                }
            } 
            while (!EmailValidation(email));
           
            return email;
        }

        public string Password()
        {
            string password = ""; 
            do
            {
                Console.Clear();      
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password must have a special charater and a digt! e.g @adesoji1 \n");
                Console.ResetColor();
                Console.Write("Your Password:\n");
                password = Console.ReadLine()!;
                Console.WriteLine("\n");

                if (!PasswordValidation(password))
                {
                    Console.WriteLine("\u001b[31m Invaild Password format! \u001b[0m");
                   
                }

            }while (!PasswordValidation(password));


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
