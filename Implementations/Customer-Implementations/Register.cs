using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MavicsBank.Interfaces.Customer_Interface;
using MavicsBank.Models.Customer_Model;

namespace MavicsBank.Implementations.Customer_Implementations
{
    internal class Register : Helper, IRegister
    {

        public void RegisterCustomer()
        {
            Console.Clear();
            RegInstruction();
            var id = CustomerId();
            var fullName = FullName();
            var email = Email();
            var password = Password();
                     

            Customer customer = new Customer(id, fullName, email, password);
            var listsInCustomerFile = ReadFromFile("Customers.txt");
            var checkListofExistingCustomers = listsInCustomerFile.FindAll(data => data.Email == email && data.Password == password);

            if (!checkListofExistingCustomers.Any())
            {
                using (StreamWriter writer = new StreamWriter("Customers.txt", true))
                {
                    writer.WriteLine($"|  {customer.Id,-12} | {customer.FullName,-16} | {customer.Email,-18} | {customer.Password,-18}  |\n\n");
                }
                CongratulateRegistrer(fullName);
                Console.WriteLine($"\u001b[34m Customer {fullName} has been added to File.\u001b[0m");  // Blue color
            }
            else
            {
                Console.WriteLine("\u001b[31m An already Existing User! Please go to Login!\u001b[0m");   // Red color
               // Console.WriteLine("One of the parameters already exist!");
            }
          
        }
    }
}
