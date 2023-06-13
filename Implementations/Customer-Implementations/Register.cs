using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using MavicsBank.Interfaces.Customer_Interface;
using MavicsBank.Models.Customer_Model;

namespace MavicsBank.Implementations.Customer_Implementations
{
    internal class Register : Helper, IRegister
    {

        public void RegisterCustomer()
        {
            RegInstruction();
            var id = CustomerId();
            var fullName = FullName();
            var email = Email();
            var password = Password();

            Customer customer = new Customer(id, fullName, email, password);

            using (StreamWriter writer = new StreamWriter("Customers.txt", true))
            {
                writer.WriteLine($"|  {customer.Id,-12} | {customer.FullName,-16} | {customer.Email,-18} | {customer.Password,-18}  |\n\n");
            }
            Console.WriteLine($" Customer {fullName} has been added to File.");
        }
    }
}
