using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MavicsBank.Models.Customer_Model
{
    public class Customer
    {
        public Customer(int id, string fullName, string email, string password)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Password = password;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }



    }
}
